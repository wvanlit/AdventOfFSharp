module Advent2021Tests.Days.Day4

open Advent2021.Days.Day4
open Helpers
open Xunit

let example = PuzzleInput.load 2021 4 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 4 PuzzleInput.Type.Puzzle


[<Fact>]
let ```Parses Bingoboard correctly`` () =
    let input =
        " 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

"

    let input = input.Split("\n")

    let expected =
        [| [| 3; 15; 0; 2; 22 |]
           [| 9; 18; 13; 17; 5 |]
           [| 19; 8; 7; 25; 23 |]
           [| 20; 11; 10; 24; 4 |]
           [| 14; 21; 16; 12; 6 |] |]

    let actual = arrayToBingoBoard input

    Assert.Equal<int[][]>(actual, expected)

[<Fact>]
let ``Can determine winning Bingo board`` () =
    let board =
        [| [| 3; 15; 0; 2; 22 |]
           [| 9; 18; 13; 17; 5 |]
           [| 19; 8; 7; 25; 23 |]
           [| 20; 11; 10; 24; 4 |]
           [| 14; 21; 16; 12; 6 |] |]

    // Valid inputs
    Assert.Equal(true, isWinning [| 22; 5; 23; 4; 6 |] board)
    Assert.Equal(true, isWinning [| 20; 11; 10; 24; 4 |] board)
    Assert.Equal(false, isWinning [| 22; 5; 23; 4; 7 |] board)
    Assert.Equal(false, isWinning [| 20; 11; 10; 24; 5 |] board)
    // Invalid inputs
    Assert.Equal(false, isWinning [| 20; 11; 10; 24; |] board)
    Assert.Equal(false, isWinning [| 1 |] board)
    Assert.Equal(false, isWinning [| |] board)

[<Fact>]
let ``Can determine when Bingo board has won`` () =
    let board =
        [| [| 3; 15; 0; 2; 22 |]
           [| 9; 18; 13; 17; 5 |]
           [| 19; 8; 7; 25; 23 |]
           [| 20; 11; 10; 24; 4 |]
           [| 14; 21; 16; 12; 6 |] |]

    // Valid inputs
    Assert.Equal(4, findTurnOfWin [| 20; 11; 10; 24; 4 |] board 0)
    Assert.Equal(5, findTurnOfWin [| 20; 11; 10; 24; 3; 4 |] board 0)

[<Fact>]
let ``Day 4.1 - Example`` () = Assert.Equal(Part1 example, 4512)

[<Fact>]
let ``Day 4.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 51776)

[<Fact>]
let ``Day 4.2 - Example`` () = Assert.Equal(Part2 example, 1924)

[<Fact>]
let ``Day 4.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 16830)
