module Advent2021Tests.Days.Day1

open Advent2021.Days.Day1
open Helpers
open Xunit

let example = PuzzleInput.load 2021 1 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 1 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Day 1.1 - Example`` () = Assert.Equal(Part1 example, 7)

[<Fact>]
let ``Day 1.2 - Example`` () = Assert.Equal(Part2 example, 5)

[<Fact>]
let ``Day 1.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 1665)

[<Fact>]
let ``Day 1.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 1702)
