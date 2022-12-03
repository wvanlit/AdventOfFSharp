module Advent2022.Days.Day3

open System
open Helpers

let parseInput (input: string) = input |> PuzzleInput.trimAndSplit

let itemsToSet (input: string) = input.ToCharArray () |> Set.ofArray

let findCommon sets =
    let common = Set.intersectMany sets
    assert (common.Count = 1)
    common.MinimumElement

let findCommonItemBetweenHalves (input: string) =
    let compartmentSize = input.Length / 2

    let firstHalf = input.Substring (0, compartmentSize) |> itemsToSet
    let secondHalf = input.Substring (compartmentSize) |> itemsToSet

    findCommon [ firstHalf; secondHalf ]

let findCommonItemBetweenElves (input: string []) = Array.map itemsToSet input |> findCommon

let getScore (input: char) =
    let score = (Char.ToUpper input |> int) - (int 'A') + 1 // Get score from 1 - 26
    if Char.IsLower input then score else score + 26

let Part1 input =
    input
    |> parseInput
    |> Array.map (findCommonItemBetweenHalves >> getScore)
    |> Array.sum

let Part2 input =
    input
    |> parseInput
    |> Array.chunkBySize 3
    |> Array.map (findCommonItemBetweenElves >> getScore)
    |> Array.sum
