﻿namespace lol

open FSharp.Data
open FSharp.Charting
open System.Windows.Forms
open System

module lol = 
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault false
    
    [<Literal>]
    let url = "http://ichart.finance.yahoo.com/table.csv?s=STO"
    
    [<Literal>]
    let url1 = "http://ichart.finance.yahoo.com/table.csv?s=DNB"
    
    [<Literal>]
    let url2 = "http://ichart.finance.yahoo.com/table.csv?s=TEL"
    
    type Statoil = CsvProvider<url, CacheRows=false>
    
    let statoil = Statoil.GetSample()
    
    type Dnb = CsvProvider<url1, CacheRows=false>
    
    let dnb = Dnb.GetSample()
    
    type Telenor = CsvProvider<url2, CacheRows=false>
    
    let telenor = Telenor.GetSample()
    
    let chart = 
        Chart.Combine([ Chart.Line([ for row in statoil.Rows -> row.Date, row.Open ])
                        Chart.Line([ for row in dnb.Rows -> row.Date, row.Open ])
                        Chart.Line([ for row in telenor.Rows -> row.Date, row.Open ]) ])
    
    [<EntryPoint>]
    [<STAThread>]
    let main argv = 
        Application.Run(chart.ShowChart())
        0
