open System
open FSharp.Data
open FSharp.Data.CsvExtensions

type Stock = 
    { date : DateTime
      openn : float
      high : float
      low : float
      close : float
      volume : float }

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

for stock in stocks do
    printfn "%A" (stock.GetType().Name)

//Date,Open,High,Low,Close,Volume,Adj Close
