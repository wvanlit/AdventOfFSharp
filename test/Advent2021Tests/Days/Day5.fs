module Advent2021Tests.Days.Day5

open Advent2021.Days.Day5
open Helpers
open Xunit

let example = PuzzleInput.load 2021 5 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 5 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Parses input correctly`` () =
    let expected =
        [| Input.line [| 0; 9; 5; 9 |]
           Input.line [| 8; 0; 0; 8 |]
           Input.line [| 9; 4; 3; 4 |]
           Input.line [| 2; 2; 2; 1 |]
           Input.line [| 7; 0; 7; 4 |]
           Input.line [| 6; 4; 2; 0 |]
           Input.line [| 0; 9; 2; 9 |]
           Input.line [| 3; 4; 1; 4 |]
           Input.line [| 0; 0; 8; 8 |]
           Input.line [| 5; 5; 8; 2 |] |]

    let parsed = example |> Input.parseInput
    Assert.Equal<Line[]>(expected, parsed)

[<Fact>]
let ``Calculates direction correctly`` () =
    Assert.Equal<LineDirection>(Horizontal, Input.lineDirection [| 0; 0; 2; 0 |])
    Assert.Equal<LineDirection>(Horizontal, Input.lineDirection [| 2; 0; 0; 0 |])

    Assert.Equal<LineDirection>(Vertical, Input.lineDirection [| 0; 0; 0; 2 |])
    Assert.Equal<LineDirection>(Vertical, Input.lineDirection [| 0; 2; 0; 0 |])

    Assert.Equal<LineDirection>(Diagonal, Input.lineDirection [| 0; 0; 2; 2 |])
    Assert.Equal<LineDirection>(Diagonal, Input.lineDirection [| 2; 2; 0; 0 |])

[<Fact>]
let ``Calculates horizontal & vertical line coverage correctly`` () =
    Assert.Equal<Position[]>(
        [| Input.point 1 1; Input.point 1 2; Input.point 1 3 |],
        Coverage.coverage (Input.line [| 1; 1; 1; 3 |])
    )

    Assert.Equal<Position[]>(
        [| Input.point 9 7; Input.point 8 7; Input.point 7 7 |],
        Coverage.coverage (Input.line [| 9; 7; 7; 7 |])
    )

[<Fact>]
let ``Calculates diagonal line coverage correctly`` () =
    Assert.Equal<Position[]>(
        [| Input.point 1 1; Input.point 2 2; Input.point 3 3 |],
        Coverage.coverage (Input.line [| 1; 1; 3; 3 |])
    )

    Assert.Equal<Position[]>(
        [| Input.point 9 7; Input.point 8 8; Input.point 7 9 |],
        Coverage.coverage (Input.line [| 9; 7; 7; 9 |])
    )

[<Fact>]
let ``Day 5.1 - Example`` () = Assert.Equal(Part1 example, 5)

[<Fact>]
let ``Day 5.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 4873)

[<Fact>]
let ``Day 5.2 - Example`` () = Assert.Equal(Part2 example, 12)

[<Fact>]
let ``Day 5.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 19472)
