module Advent2021Tests.Days.Day8

open Advent2021.Days.Day8
open Helpers
open Xunit

let example = PuzzleInput.load 2021 8 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 8 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Deducts signal correctly`` () =
    let signals =
        "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab".Split " "
        |> Seq.toList

    let actual = decode signals

    let strToStrList (s: string) =
        StringConversion.toStrList s |> List.sort

    let expected =
        Map[(strToStrList "ab", 1)
            (strToStrList "gcdfa", 2)
            (strToStrList "fbcad", 3)
            (strToStrList "eafb", 4)
            (strToStrList "cdfbe", 5)
            (strToStrList "cdfgeb", 6)
            (strToStrList "dab", 7)
            (strToStrList "acedgfb", 8)
            (strToStrList "cefabd", 9)
            (strToStrList "cagedb", 0)]

    Assert.Equal<Map<string list, int>>(expected, actual)


[<Fact>]
let ``Day 8.1 - Example`` () = Assert.Equal(Part1 example, 26)

[<Fact>]
let ``Day 8.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 525)

[<Fact>]
let ``Day 8.2 - Example`` () = Assert.Equal(Part2 example, 61229)

[<Fact>]
let ``Day 8.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 1083859)
