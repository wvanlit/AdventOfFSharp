module Advent2021.Days.Day3

open Helpers

let puzzle = PuzzleInput.load 2021 3 PuzzleInput.Type.Puzzle

let parseInput input =
    input
    |> PuzzleInput.trimAndSplit
    |> Seq.map (fun (i: string) -> i.ToCharArray() |> Seq.map string |> Seq.map int)

let countOnesAtIndex (i: int) input : int =
    input |> Seq.map (Seq.item i) |> Seq.sum

let countOnesMostCommon input =
    let half = Seq.length input / 2
    let size = Seq.item 0 input |> Seq.length

    { 0 .. (size - 1) }
    |> Seq.map (fun n -> countOnesAtIndex n input)
    |> Seq.map (fun n -> n >= half)

let sumTotalToBits input boolToByteReducer =
    input
    |> countOnesMostCommon
    |> Seq.rev
    |> Seq.indexed
    |> Seq.fold boolToByteReducer 0

let boolToByteReducer cond total (index, next) =
    total + if cond next then pown 2 index else 0

let multiplyGammaByEpsilon (bits: seq<seq<int>>) =
    let gamma = sumTotalToBits bits (boolToByteReducer id)
    let epsilon = sumTotalToBits bits (boolToByteReducer not)
    gamma * epsilon

let filterBitCriteriaForIndex (bytes: seq<seq<int>>) (currentIndex: int) (useMostCommon: bool) : seq<seq<int>> =
    let numOfOnes = (countOnesAtIndex currentIndex bytes)
    let numOfZeroes = Seq.length bytes - numOfOnes

    let keepBit =
        match useMostCommon with
        | true when numOfOnes >= numOfZeroes -> 1
        | true -> 0
        | false when numOfZeroes <= numOfOnes -> 0
        | false -> 1

    Seq.filter (fun bits -> Seq.item currentIndex bits = keepBit) bytes

let rec getRatingBits (bytes: seq<seq<int>>) (currentIndex: int) (useMostCommon: bool) : seq<int> =
    let filtered = filterBitCriteriaForIndex bytes currentIndex useMostCommon

    if Seq.length filtered = 1 then
        Seq.item 0 filtered
    else
        getRatingBits filtered (currentIndex + 1) useMostCommon


let getRating (bytes: seq<seq<int>>) useMostCommon : int =
    getRatingBits bytes 0 useMostCommon
    |> Seq.rev
    |> Seq.indexed
    |> Seq.fold (fun total (index, n) -> total + if n = 1 then pown 2 index else 0) 0

let multiplyOxygenByCO2 (bytes: seq<seq<int>>) =
    (*
    Bit Criteria
        Oxygen -> Keep nums with most common value in curr pos, if equal keep 1
        CO2 -> Keep nums with least common value in curr pos, if equal keep 0
    *)
    let oxygen = getRating bytes true
    let co2 = getRating bytes false
    oxygen * co2

let Part1 input =
    input |> parseInput |> multiplyGammaByEpsilon

let Part2 input =
    input |> parseInput |> multiplyOxygenByCO2
