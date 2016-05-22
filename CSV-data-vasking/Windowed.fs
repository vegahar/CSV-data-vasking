namespace Test

open Stock

// http://bluemountaincapital.github.io/Deedle/

module Windowed = 
    let stocks = Seq.map (fun stock -> stock.date, stock.close) Stock.stocks
    let twoDays = stocks |> Seq.windowed 30
    let run = printfn "%A" twoDays
