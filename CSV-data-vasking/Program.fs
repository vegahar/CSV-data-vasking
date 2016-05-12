﻿open FSharp.Data
open FSharp.Charting
open System.Windows.Forms
open System

Application.EnableVisualStyles()
Application.SetCompatibleTextRenderingDefault false

[<Literal>]
let url = "http://ichart.finance.yahoo.com/table.csv?s=STO"

type Statoil = CsvProvider<url, CacheRows=false>

let stocks = Statoil.GetSample()

let chart = 
    Chart.Line([ for row in stocks.Rows -> row.Date, row.Open ])


[<EntryPoint>]
[<STAThread>]
let main argv = 

    Application.Run(chart.ShowChart())
    0
