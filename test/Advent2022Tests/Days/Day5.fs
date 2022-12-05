module Advent2022Tests.Days.Day5

open Helpers
open Helpers.Tests
open Xunit

open Advent2022.Days.Day5

let day = 5

let input: TestInput<string> =
    { Part1 = { Example = "CMZ"; Puzzle = "TLFGBZHCN" }
      Part2 = { Example = "MCD"; Puzzle = "QRQFHFWCL" } }

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

[<Fact>]
let ``Input Parsing`` () =
    let (boxes, commands) = parseInput example
    Assert.NotEmpty boxes
    Assert.NotEmpty commands
