// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open DocuMark
open System.IO

open System.Text

[<EntryPoint>]
let main argv =
    try
        if (argv.Length <> 1)
            then failwith "expect one argument, the input filename"
        
        let fn = argv.[0]
        let ext = Path.GetExtension(fn).ToLowerInvariant()
        if ext = ".md" || ext = ".markdown" then
            failwith "Can't convert markdown files"

        let markdownFn = Path.ChangeExtension(fn, "md");

        printfn "Reading file: %s" fn
        let text = Documentum.readFile fn

        printfn "Converting..."
        let md = 
            text 
            |> Documentum.parse 
            |> Documentum.analyze 
            |> Documentum.processAnalysis text 
            |> Documentum.toMarkdown
            |> Documentum.breakConsecutiveLines

        printfn "Conversion done, writing to file: %s" markdownFn
        File.WriteAllText(markdownFn, md, Documentum.encoding);

        0
    with 
    | e -> 
        printf "Error: %s" (e.Message)
        5
