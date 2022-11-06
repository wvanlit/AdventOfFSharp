module Advent2021.Days.Day2

open Helpers

type Direction =
    | Forward
    | Down
    | Up

type Command = { direction: Direction; amount: int }

type Position = { horizontal: int; depth: int }

type AimedPosition = { position: Position; aim: int }

let toCommand (s: string) =
    let split = s.Split " "

    let direction =
        match split[0] with
        | "forward" -> Direction.Forward
        | "up" -> Direction.Up
        | "down" -> Direction.Down
        | unknown -> failwithf $"Invalid direction: %s{unknown}"

    { direction = direction
      amount = int split[1] }

let puzzle = PuzzleInput.load 2021 2 PuzzleInput.Type.Puzzle

let parseInput input =
    input |> PuzzleInput.trimAndSplit |> Array.map toCommand |> Array.toSeq

let movePart1 current command =
    match command.direction with
    | Direction.Forward -> { current with horizontal = current.horizontal + command.amount }
    | Direction.Up -> { current with depth = current.depth - command.amount }
    | Direction.Down -> { current with depth = current.depth + command.amount }

let movePart2 current command =
    match command.direction with
    | Direction.Forward ->
        { current with
            position =
                { current.position with
                    horizontal = current.position.horizontal + command.amount
                    depth = current.position.depth + current.aim * command.amount } }
    | Direction.Up -> { current with aim = current.aim - command.amount }
    | Direction.Down -> { current with aim = current.aim + command.amount }

let multiplyPosition p = p.horizontal * p.depth

let Part1 input =
    input
    |> parseInput
    |> Seq.fold movePart1 { Position.horizontal = 0; depth = 0 }
    |> multiplyPosition

let Part2 input =
    input
    |> parseInput
    |> Seq.fold
        movePart2
        { position = { horizontal = 0; depth = 0 }
          aim = 0 }
    |> fun r -> multiplyPosition r.position
