namespace Test

open Stock

module Windowed = 
    let stocks = Seq.map (fun stock -> stock.date, stock.close) Stock.stocks
    let twoDays = stocks |> Seq.windowed 30



    let run = printfn "%A" twoDays
