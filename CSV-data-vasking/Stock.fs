namespace Test

open System
open FSharp.Data
open FSharp.Data.CsvExtensions

module Stock = 
    type Stock = 
        { date : DateTime
          openn : float
          high : float
          low : float
          close : float }
    
    type ClassifiedStock = 
        | StockIsDown
        | StockIsUp
    
    let csv = CsvFile.Load("http://ichart.finance.yahoo.com/table.csv?s=AAPL").Rows
    
    let mapRowToStock (row : CsvRow) = 
        { date = row?Date.AsDateTime()
          openn = row?Open.AsFloat()
          high = row?High.AsFloat()
          low = row?Low.AsFloat()
          close = row?Close.AsFloat() }
    
    let classifyStock (stock : Stock) : ClassifiedStock = 
        if stock.close <= stock.openn then StockIsDown
        else StockIsUp
    
    let classifiedStocks = 
        csv
        |> Seq.map mapRowToStock
        |> Seq.map classifyStock
        |> Seq.map (function 
               | StockIsDown -> "Dårlig dag"
               | StockIsUp -> "Bra dag")
        |> Seq.groupBy (fun word -> word)
        |> Seq.map (fun (key, value) -> key, Seq.length value)
    
    let classifiedStocksNotReadable = 
        Seq.map (fun (key, value) -> key, Seq.length value) 
            (Seq.groupBy (fun word -> word) 
                 (Seq.map (function 
                      | StockIsDown -> "Dårlig dag"
                      | StockIsUp -> "Bra dag") (Seq.map classifyStock (Seq.map mapRowToStock csv))))
    
    let run = 
        printfn "%A" classifiedStocks
        printfn "%A" classifiedStocksNotReadable
