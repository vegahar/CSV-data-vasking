namespace Test

open Vasking
open Stock
open Visualisering

module Program = 

    //http://fsharp.github.io/FSharp.Data/
    //http://fslab.org/FSharp.Charting/

    [<EntryPoint>]
    let main argv = 
        Visualisering.run; 
        Stock.run
        0
