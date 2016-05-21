﻿open System
open FSharp.Data
open FSharp.Data.CsvExtensions

type Stock = 
    { date : DateTime
      openn : float
      high : float
      low : float
      close : float }

type ClassifiedStock = 
    | StockIsDown
    | StockIsUp

let classifyStock (stock : Stock) : ClassifiedStock = 
    if stock.close <= stock.openn then StockIsDown
    else StockIsUp

let csv = CsvFile.Load("http://ichart.finance.yahoo.com/table.csv?s=AAPL").Rows

let mapRowToStock (row : CsvRow) = 
    { date = row?Date.AsDateTime()
      openn = row?Open.AsFloat()
      high = row?High.AsFloat()
      low = row?Low.AsFloat()
      close = row?Close.AsFloat() }

let classifiedStocks = 
    csv
    |> Seq.map mapRowToStock
    |> Seq.map classifyStock
    |> Seq.map (function 
           | StockIsDown -> "Dårlig dag"
           | StockIsUp -> "Bra dag")
    |> Seq.groupBy (fun word -> word)
    |> Seq.map (fun (key, value) -> key, Seq.length value)

printfn "%A" classifiedStocks
