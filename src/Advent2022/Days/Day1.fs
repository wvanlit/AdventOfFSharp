module Advent2022.Days.Day1

open Helpers

let groupByEmptyLine (list: string[]) =
    list
    |> Array.rev // Fold works backwards
    |> Array.fold
        (fun (state: int list list) next ->
            match next with
            | "" -> [] :: state
            | str -> (int str :: state.Head) :: state.Tail)
        [ [] ]

let parseInput (input: string) =
    input |> PuzzleInput.trimAndSplit |> groupByEmptyLine

let Part1 input =
    input |> parseInput |> List.map List.sum |> List.max

let Part2 input =
    input
    |> parseInput
    |> List.map List.sum
    |> List.sortDescending
    |> List.take 3
    |> List.sum
