open FSharp.Data
open System

let urlBase = "http://ichart.finance.yahoo.com/table.csv?s="
let companyStockNames = [ "STO"; "DNB"; "TEL" ]
let companyStockUrl company : string = urlBase + company
let literals = List.map companyStockUrl companyStockNames

for lit in literals do
    printfn "%s" (lit)

let readCsvUrl (url : string) = CsvFile.Load(url).Cache()
let csvFiles = List.map readCsvUrl literals

let firstResult = 
    csvFiles
    |> Seq.map (fun file -> file.Rows)
    |> Seq.map (fun rows -> Seq.head rows)

for a in firstResult do
    printfn "%s" (a.GetColumn("High"))

[<EntryPoint>]
let main argv = 0
