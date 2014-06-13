namespace DocuMark.Tests

open FsUnit
open NUnit.Framework

open DocuMark
open ScanRat

open System.IO


[<TestFixture>]
type DocuMarkTests() =


    let valueOf success = 
        match success with
        | Success {value = value} ->
            value
        | Failure f ->
            sprintf "failure %A" f |> failwith

    let analyze text = Documentum.parse text |> Documentum.analyze |> Documentum.processAnalysis text

    let toMarkdown text =
        analyze text |> Documentum.toMarkdown

    [<Test>]
    member this.stringConversionConvertsUmlautsProperly() =
        let str = Documentum.readFile "Umlauts.text"
        str |> should equal "ChunkGröße\n"

    [<Test>]
    member this.syntaxParsesBeginTag() =
        parse DocuParser.syntax "/UK" |> valueOf |> should equal [BeginTag (0,"UK")]

    [<Test>]
    member this.syntaxParsesBeginTag2() =
        parse DocuParser.syntax "(/UK" |> valueOf |> should equal [Word (0, "("); BeginTag (1,"UK")]

    [<Test>]
    member this.syntaxParsesendTag() =
        parse DocuParser.syntax " UK/" |> valueOf |> should equal [Space (0, " "); EndTag (1, "UK")]

    [<Test>]
    member this.syntaxParsesBeginEnd() = 
        parse DocuParser.syntax "/UK E UK/" |> valueOf |> should equal [BeginTag (0, "UK"); Space (3, " "); Word (4, "E"); Space (5, " "); EndTag (6, "UK")]

    [<Test>]
    member this.analyzeCop() =
        let text = Documentum.readFile "Ref_Cop.text"
        text |> analyze |>  ignore

    [<Test>]
    member this.analyzeTop() =
        let text = Documentum.readFile "Ref_Top.text"
        text |> analyze |>  ignore

    [<Test>]
    member this.analyzeRap() =
        let text = Documentum.readFile "Ref_Rap.text"
        text |> analyze |>  ignore
