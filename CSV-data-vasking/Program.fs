namespace Test

open System
open FSharp.Data
open FSharp.Data.CsvExtensions
open Vasking
open Stock
open Visualisering

module Program = 
    [<EntryPoint>]
    let main argv = 
        Visualisering.run; 
        Stock.run
        0
