namespace Test

open FSharp.Data
open FSharp.Charting
open System.Windows.Forms
open System

module Visualisering = 
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault false
    
    [<Literal>]
    let url = "http://ichart.finance.yahoo.com/table.csv?s=STO"
    
    type Statoil = CsvProvider<url, CacheRows=true>
    
    // Gir deg typen
    //Statoil.Row
    let stocks = Statoil.GetSample()
    
    let chart = 
        Chart.Combine([ Chart.Line([ for row in stocks.Rows -> row.Date, row.Open ], Name = "Open")
                        Chart.Line([ for row in stocks.Rows -> row.Date, row.High ], Name = "High")
                        Chart.Line([ for row in stocks.Rows -> row.Date, row.Low ], Name = "Low")
                        Chart.Line([ for row in stocks.Rows -> row.Date, row.Close ], Name = "Close") ])
        |> Chart.WithLegend(InsideArea = true)
        |> Chart.WithYAxis(Max = 50.0, Min = 0.0)
    
    let stockChart = 
        Chart.Stock([ for row in stocks.Rows -> row.Date, row.High, row.Low, row.Open, row.Close ])
    
    [<STAThread>]
    let run = 
        Application.Run(chart.ShowChart())
        Application.Run(stockChart.ShowChart())
