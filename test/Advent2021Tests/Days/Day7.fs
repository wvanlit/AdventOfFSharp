module Advent2021Tests.Days.Day7

open Advent2021.Days.Day7
open Helpers
open Xunit

let example = PuzzleInput.load 2021 7 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 7 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Calculates Part 2 fuel correctly`` () =
    Assert.Equal(fuelForPart2 16 5, 66)
    Assert.Equal(fuelForPart2 1 5, 10)
    Assert.Equal(fuelForPart2 2 5, 6)
    Assert.Equal(fuelForPart2 0 5, 15)
    Assert.Equal(fuelForPart2 4 5, 1)
    Assert.Equal(fuelForPart2 2 5, 6)
    Assert.Equal(fuelForPart2 7 5, 3)
    Assert.Equal(fuelForPart2 1 5, 10)
    Assert.Equal(fuelForPart2 2 5, 6)
    Assert.Equal(fuelForPart2 14 5, 45)

[<Fact>]
let ``Day 7.1 - Example`` () = Assert.Equal(Part1 example, 37)

[<Fact>]
let ``Day 7.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 348664)

[<Fact>]
let ``Day 7.2 - Example`` () = Assert.Equal(Part2 example, 168)

[<Fact>]
let ``Day 7.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 100220525)
