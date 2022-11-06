module Advent2021.Days.Day8

open System
open Helpers

let puzzle = PuzzleInput.load 2021 8 PuzzleInput.Type.Puzzle

let digitsSegments =
    Map
        [ (1, [ 'c'; 'f' ])
          (7, [ 'a'; 'c'; 'f' ])
          (4, [ 'b'; 'c'; 'd'; 'f' ])
          (2, [ 'a'; 'c'; 'd'; 'e'; 'g' ])
          (3, [ 'a'; 'c'; 'd'; 'f'; 'g' ])
          (5, [ 'a'; 'b'; 'd'; 'f'; 'g' ])
          (6, [ 'a'; 'b'; 'd'; 'e'; 'f'; 'g' ])
          (9, [ 'a'; 'b'; 'c'; 'd'; 'f'; 'g' ])
          (0, [ 'a'; 'b'; 'c'; 'e'; 'f'; 'g' ])
          (8, [ 'a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g' ]) ]


let parseSignalPattern (input: string) =
    let split = input.Split " | "
    let patterns = split[ 0 ].Split " " |> Seq.toList
    let output = split[ 1 ].Split " " |> Seq.toList
    (patterns, output)

let parseInput input =
    input |> PuzzleInput.trimAndSplit |> Array.map parseSignalPattern |> Seq.toList

let toDigitCount (str: string) = str.Length

let hasEqualSegments digit str =
    toDigitCount str = (digitsSegments.Item digit |> List.length)

let isUniqueLenghtDigit str =
    [ hasEqualSegments 1
      hasEqualSegments 4
      hasEqualSegments 7
      hasEqualSegments 8 ]
    |> List.map (fun f -> f str)
    |> List.contains true

let decode signal : Map<string list, int> =
    let signal = signal |> List.sortBy String.length

    let findSingle (i: int) =
        signal |> List.find (hasEqualSegments i) |> StringConversion.toStrList

    let findMultiple (i: int) =
        List.filter (hasEqualSegments i) signal |> List.map StringConversion.toStrList

    let notInOtherSignal signal other =
        List.filter (fun x -> (List.contains x >> not) other) signal

    let singleNotInOtherSignal signal other =
        let result = notInOtherSignal signal other

        if List.length result = 1 then
            result.Head
        else
            failwith "Result had multiple return values!"

    let hasSegment digit segment = List.contains segment digit

    let hasAllSegments segments digit = List.forall (hasSegment digit) segments

    let contains segments possible =
        List.filter (hasAllSegments segments) possible

    let removeSegment segment segments =
        List.filter (fun x -> x <> segment) segments

    let one = findSingle 1
    let four = findSingle 4
    let seven = findSingle 7
    let eight = findSingle 8

    let twoOrThreeOrFive = findMultiple 2
    let zeroOrSixOrNine = findMultiple 0

    let segmentA = singleNotInOtherSignal seven one
    let segmentBandD = notInOtherSignal four one
    let segmentEandG = notInOtherSignal eight (List.append four [ segmentA ])

    let six =
        contains (List.concat [ segmentEandG; segmentBandD ]) zeroOrSixOrNine
        |> List.head


    let segmentC = singleNotInOtherSignal eight six

    let two = contains segmentEandG twoOrThreeOrFive |> List.head
    let threeOrFive = removeSegment two twoOrThreeOrFive
    let three = contains [ segmentC ] threeOrFive |> List.head
    let five = removeSegment three threeOrFive |> List.head

    let segmentBandF = notInOtherSignal six two
    let segmentF = singleNotInOtherSignal one [ segmentC ]
    let segmentB = singleNotInOtherSignal segmentBandF [ segmentF ]
    let segmentD = singleNotInOtherSignal segmentBandD [ segmentB ]

    let zeroOrNine = removeSegment six zeroOrSixOrNine
    let nine = contains [ segmentD ] zeroOrNine |> List.head
    let zero = removeSegment nine zeroOrNine |> List.head

    Map
        [ (List.sort zero,0)
          (List.sort one,1)
          (List.sort two,2)
          (List.sort three,3)
          (List.sort four,4)
          (List.sort five,5)
          (List.sort six,6)
          (List.sort seven,7)
          (List.sort eight,8)
          (List.sort nine, 9)]

let decryptOutput ((map, output): Map<string list, int> * string list) =
    let output = List.map (StringConversion.toStrList >> List.sort) output
    let keys = List.map (fun k -> Map.find k map) output
    keys |> List.map (fun i -> i.ToString()) |> String.concat "" |> int


let Part1 input =
    input
    |> parseInput
    |> List.map snd
    |> List.map (List.filter isUniqueLenghtDigit >> List.length)
    |> List.sum

let Part2 input =
    input
    |> parseInput
    |> List.map (fun (signal, output) -> (decode signal, output))
    |> List.map decryptOutput
    |> List.sum
