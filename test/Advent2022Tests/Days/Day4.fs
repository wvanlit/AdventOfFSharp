module Advent2022Tests.Days.Day4

open Helpers
open Helpers.Tests
open Xunit

open Advent2022.Days.Day4

let day = 4

let input: TestInput =
    { Part1 = { Example = 1; Puzzle = 1 }
      Part2 = { Example = 2; Puzzle = 2 } }

let example =
    PuzzleInput.load 2022 day PuzzleInput.Type.Example

let puzzle =
    PuzzleInput.load 2022 day PuzzleInput.Type.Puzzle

[<Fact>]
let ``Part 1 - Example`` () =
    Assert.Equal (input.Part1.Example, Part1 example)

[<Fact>]
let ``Part 1 - Puzzle`` () =
    Assert.Equal (input.Part1.Puzzle, Part1 puzzle)

[<Fact>]
let ``Part 2 - Example`` () =
    Assert.Equal (input.Part2.Example, Part2 example)

[<Fact>]
let ``Part 2 - Puzzle`` () =
    Assert.Equal (input.Part2.Puzzle, Part2 puzzle)
