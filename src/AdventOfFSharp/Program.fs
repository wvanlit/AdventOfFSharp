open Advent2021

printfn "Advent of Code 2021"

Solutions.allDays()
|> Array.iter (fun (title, output) -> printfn $"{title} -> {output}")
