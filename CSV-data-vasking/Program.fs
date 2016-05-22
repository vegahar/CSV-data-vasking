namespace Test

module Program = 

    //http://fsharp.github.io/FSharp.Data/
    //http://fslab.org/FSharp.Charting/

    [<EntryPoint>]
    let main argv = 
        Visualisering.run; 
        Stock.run
        Windowed.run
        0
