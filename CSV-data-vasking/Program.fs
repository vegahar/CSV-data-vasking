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

let buybuy (stock : Stock) = stock.close <= stock.openn
let sellsell (stock : Stock) = stock.close > stock.openn

type ClassifiedStock = 
    | Buy
    | Sell

let classifyStock (stock : Stock) : ClassifiedStock = 
    if stock.close <= stock.openn then Buy
    else Sell

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
    | Buy -> "Buy buy!!"
    | Sell -> "Sell sell!!"

for stock in classifiedStocks do
    printfn "%A" (matchStock stock)
//for stock in stocks do
//  printfn "%A" (stock.GetType().Name)
//Date,Open,High,Low,Close,Volume,Adj Close
