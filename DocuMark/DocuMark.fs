module DocuMark

open System
open System.IO
open ScanRat
open System.Linq

type ConvSpec = 
    | Header of string
    | Span of string * string
    | Ignore
    | Indent of string

let convTable =
    [
        "UK", Header "#";
        "U1", Header "##";
        "U2", Header "###";
        "U3", Header "####";
        "U4", Header "#####";
        "U5", Header "######";
        "i", Span ("*","*");
        "ZK", Span ("*","*");
        "ZM", Span ("`","`"); /// Buttons?
        "E2", Indent "- ";
        "E4", Indent "\t- ";
        "ZB", Span ("`","`"); /// Keyboard Keys / Shortcuts?
        "ZL", Indent "\t"; /// Code
        "ZY", Span ("`", "`"); // ?
    ]


let convMap = Map.ofSeq convTable

let chars2str chars = 
    let array = List.toArray chars
    String(array)

type Syntax = 
    | BeginTag of (int * string)
    | EndTag of (int * string)
    | Word of (int * string)
    | Space of (int * string)

module DocuParser =

    let knownTags = 
        convTable 
        |> List.map fst 
        |> List.map (~~)
        |> function 
            | [] -> failwith "no known tags"
            | head::tail -> List.fold (|-) head tail

    let space = oneOf " \t\n\r"
    let endOrSpace = matchEnd |- (space --> ignore)

    let slash = ~~"/"
    let slashChar = matchChar "slash" '/'

    let spaces = space.oneOrMore --> chars2str -->. Space

    let beginTag = slash +. knownTags +! (!!endOrSpace) -->. BeginTag

    let endTag = (matchBack 1 space) +. knownTags .+ slash -->. EndTag

    let anyChar = matchCharFun "anychar" (fun c -> true)
    let wordChar = anyChar / (slashChar |- space)

    let word = wordChar.oneOrMore --> chars2str -->. Word
    // let slashWord = slash +! knownTags --> Word 

    let element =
        beginTag 
        |- endTag
        |- spaces
        |- word
        |- slash -->. Word

    let syntax = element.many

module Documentum =

    let encoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

    let readFile (filename:string) = 
        use file = new StreamReader(filename, encoding, false)
        file.ReadToEnd()

    let position (text:string) index = 
        let textBefore = text.Substring(0, index);
        let lineNumber = textBefore |> Seq.filter ((=) '\n') |> Seq.length |> (+) 1
        let columnNumber = 
            match text.LastIndexOf('\n') with
            | -1 -> index + 1
            | i -> text.Length - i

        lineNumber, columnNumber

    let context (text: string) i =
        let context = 20
        let beforeCount = Math.Min(i, context)
        let failureBefore = text.Substring(i - beforeCount, beforeCount)
        let afterCount = Math.Min(context, text.Length-i)
        let failureStr = text.Substring(i, afterCount)
        sprintf "%s_%s" failureBefore failureStr

    let parse (text : string) : Syntax list =
        let valueOf success = 
            match success with
            | Success {value = value} ->
                value
            | Failure f ->
                let pos = f.index |> position text
                sprintf "failure %A %s" pos (context text (f.index)) |> failwith
    
        parse DocuParser.syntax text |> valueOf

    type Structure = 
        | Tagged of (int * string) * Structure list
        | Content of (int * string)
        | Structure of Structure list

    type AnalysisResult =
        | AnalysisError of int * string
        | Analysis of Structure
    


    let analyze syntax = 

        let rec analyzer stack soFar todo =
            match todo with
            | Word word :: rest -> analyzer stack (Content word :: soFar) rest
            | Space space :: rest -> analyzer stack (Content space :: soFar) rest
            | BeginTag tag :: rest -> analyzer ((tag, soFar) :: stack) [] rest
            | EndTag (i, etag) :: rest ->
                match stack with
                | ((_, t as tag), pending) :: stack when t = etag -> 
                    let contained = Tagged (tag, soFar |> List.rev)
                    analyzer stack (contained::pending) rest
                | ((_, tag), pending) :: _ -> 
                    let err = sprintf "Found end tag '%s' but with '%s' begin tag before" etag tag
                    AnalysisError (i, err)
                | [] -> 
                    let err = sprintf "Found end tag '%s' without related begin tag" etag
                    (i, err) |> AnalysisError
            | [] ->
                match stack with
                | ((i, tag), _)::_ -> 
                    let err = sprintf "End of text, but seen unclosed tag '%s'" tag
                    (i, err) |> AnalysisError
                | [] -> soFar |> List.rev |> Structure |> Analysis

        analyzer [] [] syntax
     
    let processAnalysis text r = 
        match r with
        | AnalysisError (i, str) ->
            let pos = position text i
            let context = context text i
            sprintf "analysis failed: %s @ %A %s" str pos context |> failwith
        | Analysis structure -> structure

    let private splitLines (content: string) = content.Split('\n')
    let private joinLines (lines: string seq) = String.Join("\n", Seq.toArray lines)

    let private indentLines str = Seq.map (fun l -> str + l)

    let private indent str content =
        content
        |> splitLines
        |> indentLines str
        |> joinLines


    let private convertMarkdown spec content = 
        match spec with
        | Header h -> h + content
        // | Block (top, bottom) -> top + content + bottom
        | Ignore -> content
        | Indent str -> indent str content
        | Span (pre, post) -> pre + content.Trim() + post
         

    let rec toMarkdown structure = 
        match structure with
        | Content (_, str) -> str
        | Structure l -> l |> List.map toMarkdown |> List.fold (+) ""
        | Tagged ((_, tag), content) ->
            let converter = convMap.[tag]
            convertMarkdown converter (toMarkdown (Structure content))


    let breakConsecutiveLines (content:string) = 
        let lines = splitLines content
        let s = seq {
            for i in [0..lines.Length - 1] do
                if i = lines.Length - 1 then
                    yield lines.[i]
                else
                let l1 = lines.[i].TrimEnd()
                let l2 = lines.[i+1].TrimEnd()
                // a tab-indented line is not touched
                if (l1 <> "" && l1.[0] <> '\t' && l2 <> "" && l2.[0] <> '\t') then
                    yield l1 + "  "; // markdown for "do not break the next line"
                else
                    yield lines.[i]
        }
        s |> joinLines

