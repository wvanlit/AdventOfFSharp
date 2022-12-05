module Advent2022Tests.Days.Day2

open Advent2022.Days.Day2
open Helpers
open Helpers.Tests
open Xunit

let day = 2

let input: TestInput<int> =
    { Part1 = { Example = 15; Puzzle = 13446 }
      Part2 = { Example = 12; Puzzle = 13509 } }

let example = PuzzleInput.load 2022 day PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2022 day PuzzleInput.Type.Puzzle

[<Fact>]
let ``Part 1 - Example`` () = Assert.Equal (input.Part1.Example, Part1 example)

[<Fact>]
let ``Part 1 - Puzzle`` () = Assert.Equal (input.Part1.Puzzle, Part1 puzzle)

[<Fact>]
let ``Part 2 - Example`` () = Assert.Equal (input.Part2.Example, Part2 example)

[<Fact>]
let ``Part 2 - Puzzle`` () = Assert.Equal (input.Part2.Puzzle, Part2 puzzle)
