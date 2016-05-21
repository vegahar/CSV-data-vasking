open System
open FSharp.Data
open FSharp.Data.CsvExtensions

type Close = float

type Open = float

type Stock = 
    { date : DateTime
      openn : Open
      high : float
      low : float
      close : Close
      volume : float }

type ClassifiedStock = 
    | StockIsDown
    | StockIsUp

let classifyStock (stock : Stock) : ClassifiedStock = 
    if stock.close <= stock.openn then StockIsDown
    else StockIsUp

let csv = CsvFile.Load("http://ichart.finance.yahoo.com/table.csv?s=AAPL")
let headerRow = csv.Headers
let rows = csv.Rows

let mapRowToStock (row : CsvRow) = 
    { date = row?Date.AsDateTime()
      openn = row?Open.AsFloat()
      high = row?High.AsFloat()
      low = row?Low.AsFloat()
      close = row?Close.AsFloat()
      volume = row?Volume.AsFloat() }

let stocks = Seq.map mapRowToStock rows
let classifiedStocks = Seq.map classifyStock stocks

let matchStock (stock : ClassifiedStock) = 
    match stock with
    | StockIsDown -> "Buy buy!!"
    | StockIsUp -> "Sell sell!!"

let groupedBy = 
    classifiedStocks
    |> Seq.map matchStock
    |> Seq.groupBy (fun word -> word)
    |> Seq.map (fun (key, value) -> key, Seq.length value)

printfn "%A" groupedBy
