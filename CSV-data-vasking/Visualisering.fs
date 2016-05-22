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

    type Statoil = CsvProvider<url, CacheRows=false>

    // Gir deg typen
    //Statoil.Row
    
    let stocks = Statoil.GetSample()

    let chart =
        Chart.Line([ for row in stocks.Rows -> row.Date, row.Open ])

    [<STAThread>]
    let run =
        Application.Run(chart.ShowChart())

