module Advent2022Tests.Days.Day1

open Advent2022.Days.Day1
open Helpers
open Xunit

let example = PuzzleInput.load 2022 1 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2022 1 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Day 1.1 - Example`` () = Assert.Equal(24000, Part1 example)

[<Fact>]
let ``Day 1.2 - Example`` () = Assert.Equal(45000, Part2 example)

[<Fact>]
let ``Day 1.1 - Puzzle`` () = Assert.Equal(74198, Part1 puzzle)

[<Fact>]
let ``Day 1.2 - Puzzle`` () = Assert.Equal(209914, Part2 puzzle)

[<Fact>]
let ``Groups input correctly`` () =
    let expected =
        [ [ 1000; 2000; 3000 ]
          [ 4000 ]
          [ 5000; 6000 ]
          [ 7000; 8000; 9000 ]
          [ 10000 ] ]

    Assert.Equal<int list list>(parseInput example, expected)
