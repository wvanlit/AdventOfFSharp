module Advent2021.Days.Day5

open System
open Helpers

let puzzle = PuzzleInput.load 2021 5 PuzzleInput.Type.Puzzle

type LineDirection =
    | Horizontal
    | Vertical
    | Diagonal

type Position = { x: int; y: int }

type Line =
    { start: Position
      ending: Position
      direction: LineDirection }

module Input =
    let lineDirection (points: int[]) =
        let dx = Math.Abs(points[0] - points[2])
        let dy = Math.Abs(points[1] - points[3])

        match (dx > 0, dy > 0) with
        | (true, true) -> Diagonal
        | (false, false) -> Diagonal
        | (true, false) -> Horizontal
        | (false, true) -> Vertical

    let point x y = { x = x; y = y }

    let line (points: int[]) =
        { start = point points[0] points[1]
          ending = point points[2] points[3]
          direction = lineDirection points }

    let parseLine (input: string) =
        input.Replace(" -> ", ",").Split "," |> Array.map int |> line

    let parseInput input = input |> PuzzleInput.trimAndSplit |> Array.map parseLine

module Coverage =
    let delta x y =
        if x - y = 0 then 0
        elif x - y < 0 then 1
        else -1

    let lineLength start ending =
        Math.Max(Math.Abs(start.x - ending.x), Math.Abs(start.y - ending.y))

    let coverage line =
        let dx = delta line.start.x line.ending.x
        let dy = delta line.start.y line.ending.y
        let steps = lineLength line.start line.ending

        let pointAtStep n =
            Input.point (line.start.x + dx * n) (line.start.y + dy * n)

        [| 0..steps |] |> Array.map pointAtStep

let flatMap f arr = arr |> Array.map f |> Array.collect id

let countGroupedWhere cond arr =
    arr |> Array.groupBy id |> Array.filter cond |> Array.length

let Part1 input =
    input
    |> Input.parseInput
    |> Array.filter (fun l -> l.direction <> Diagonal)
    |> flatMap Coverage.coverage
    |> countGroupedWhere (fun (_, occurrences) -> Array.length occurrences > 1)

let Part2 input =
    input
    |> Input.parseInput
    |> flatMap Coverage.coverage
    |> countGroupedWhere (fun (_, occurrences) -> Array.length occurrences > 1)
