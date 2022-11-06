module Advent2021Tests.Days.Day2

open Advent2021.Days.Day2
open Helpers
open Xunit

let example = PuzzleInput.load 2021 2 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 2 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Day 2.1 - Example`` () = Assert.Equal(Part1 example, 150)

[<Fact>]
let ``Day 2.2 - Example`` () = Assert.Equal(Part2 example, 900)

[<Fact>]
let ``Day 2.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 1989014)

[<Fact>]
let ``Day 2.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 2006917119)
