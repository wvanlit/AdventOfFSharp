module Advent2022.Days.Day4

open Helpers

let parseInput (input: string) = input |> PuzzleInput.trimAndSplit

let toTuple (list: 'a []) = (list[0], list[1])

let parseRange (input: string) = input.Split "-" |> Array.map int |> toTuple

let parseLine (input: string) = input.Split "," |> Array.map parseRange |> toTuple

let isFullyContainedIn (start1, end1) (start2, end2) = start1 >= start2 && end1 <= end2

let isPartiallyContainedIn (start1, end1) (start2, end2) = end1 >= start2 && start1 <= end2

let isEither func (area1, area2) = func area1 area2 || func area2 area1

let Part1 input =
    input
    |> parseInput
    |> Array.map parseLine
    |> Array.where (isEither isFullyContainedIn)
    |> Array.length

let Part2 input =
    input
    |> parseInput
    |> Array.map parseLine
    |> Array.where (isEither isPartiallyContainedIn)
    |> Array.length
