module Advent2021.Days.Day4

open System
open Helpers

type BingoBoard = int[][]
type DrawnNumbers = int[]

type BingoSubsystem =
    { numbers: DrawnNumbers
      boards: BingoBoard[] }

let puzzle = PuzzleInput.load 2021 4 PuzzleInput.Type.Puzzle

let parseBingoLine (s: string) =
    s.ToCharArray() |> Array.chunkBySize 3 |> Array.map (fun x -> String(x) |> int)

let arrayToBingoBoard (arr: string[]) = arr[0..4] |> Array.map parseBingoLine

let parseInput (input: string) =
    let lines = PuzzleInput.trimAndSplit input
    let drawnNumbers: DrawnNumbers = lines[ 0 ].Split(",") |> Array.map int

    let bingoBoards: BingoBoard[] =
        lines[2..] |> Array.chunkBySize 6 |> Array.map arrayToBingoBoard

    { numbers = drawnNumbers
      boards = bingoBoards }

let boardToRows (board: BingoBoard) =
    Array.concat [| board[0..]; (Array.transpose board)[0..] |]

let isWinningSequence drawn sequence : bool =
    Array.forall (fun n -> drawn |> Array.contains n) sequence

let isWinning drawn (board: BingoBoard) =

    Array.length drawn >= 5
    && boardToRows board |> Array.map (isWinningSequence drawn) |> Array.contains true

let getUnmarkedNumbers (numbers: DrawnNumbers) (turn: int) (board: BingoBoard) =
    board
    |> Array.collect id
    |> Array.filter ((fun x -> Array.contains x numbers[0..turn]) >> not)

let rec findTurnOfWin (numbers: DrawnNumbers) (board: BingoBoard) (turn: int) : int =
    let isWinningTurn = isWinning numbers[0..turn] board

    if isWinningTurn then
        turn
    else
        findTurnOfWin numbers board (turn + 1)

let rec findWinningBoards turn subsystem =
    let boards =
        subsystem.boards
        |> Array.map (fun board -> (board, findTurnOfWin subsystem.numbers board turn))

    let (first, turn) = boards |> Array.sortBy snd |> Array.head
    (subsystem, turn, first)

let rec findLastBoard turn subsystem =
    let boards =
        subsystem.boards
        |> Array.map (fun board -> (board, findTurnOfWin subsystem.numbers board turn))

    let (last, turn) = boards |> Array.sortBy snd |> Array.last
    (subsystem, turn, last)

let Part1 input =
    let (subsystem, turn, winning) = input |> parseInput |> findWinningBoards 5
    let unmarkedSum = getUnmarkedNumbers subsystem.numbers turn winning |> Array.sum

    unmarkedSum * subsystem.numbers[turn]

let Part2 input =
    let (subsystem, turn, last) = input |> parseInput |> findLastBoard 5
    let unmarkedSum = getUnmarkedNumbers subsystem.numbers turn last |> Array.sum

    unmarkedSum * subsystem.numbers[turn]
