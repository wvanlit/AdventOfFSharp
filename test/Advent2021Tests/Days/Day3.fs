module Advent2021Tests.Days.Day3

open Advent2021.Days.Day3
open Helpers
open Xunit

let example = PuzzleInput.load 2021 3 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 3 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Day 3.1 - Example`` () = Assert.Equal(Part1 example, 198)

[<Fact>]
let ``Day 3.2 - Example`` () = Assert.Equal(Part2 example, 230)

[<Fact>]
let ``Day 3.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 3309596)

[<Fact>]
let ``Day 3.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 2981085)
