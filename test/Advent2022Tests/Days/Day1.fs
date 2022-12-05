module Advent2022Tests.Days.Day1

open Advent2022.Days.Day1
open Helpers
open Helpers.Tests
open Xunit

let day = 1

let input: TestInput<int> =
    { Part1 = { Example = 24000; Puzzle = 74198 }
      Part2 = { Example = 45000; Puzzle = 209914 } }

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
let ``Groups input correctly`` () =
    let expected =
        [ [ 1000; 2000; 3000 ]
          [ 4000 ]
          [ 5000; 6000 ]
          [ 7000; 8000; 9000 ]
          [ 10000 ] ]

    Assert.Equal<int list list> (parseInput example, expected)
