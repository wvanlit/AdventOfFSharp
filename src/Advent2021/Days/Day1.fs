module Advent2021.Days.Day1

open Helpers

let puzzle = PuzzleInput.load 2021 1 PuzzleInput.Type.Puzzle

let parseInput (input: string) = input |> PuzzleInput.trimAndSplit |> Array.map int |> Array.toSeq

let totalWhereSecondItemLarger list =
    list |> Seq.windowed 2 |> Seq.filter (fun a -> a[0] < a[1]) |> Seq.length

let Part1 input =
    input |> parseInput |> totalWhereSecondItemLarger

let Part2 input =
    input
    |> parseInput
    |> Seq.windowed 3
    |> Seq.map Seq.sum
    |> totalWhereSecondItemLarger
