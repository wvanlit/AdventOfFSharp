module Advent2021.Days.Day7

open System
open Helpers

let puzzle = PuzzleInput.load 2021 7 PuzzleInput.Type.Puzzle

type CrabPosition = int
type FuelUsage = int
type CrabPositions = Counter.Counter<CrabPosition>

let parseInput (input: string) : CrabPositions =
    input.Split "," |> Seq.map int |> Seq.toList |> Counter.fromList

let fuelForPart1 (position: CrabPosition) target = Math.Abs(position - target)

let fuelForPart2 (position: CrabPosition) target =
    [ 1 .. Math.Abs(target - position) ] |> List.sum

let calculateFuelCost fuelTo crabs target =
    crabs |> List.map (fun (pos, n) -> fuelTo pos target * int n) |> List.sum

let onlyGivenPositions positions = positions |> List.map fst

let allPositionsBetween (positions: CrabPositions) =
    let sorted = List.sortBy fst positions |> List.map fst
    [ List.head sorted .. List.last sorted ]

let findOptimalUsage (validPositions) (scorer: CrabPositions -> CrabPosition -> FuelUsage) (positions: CrabPositions) =
    let scoreFunc = scorer positions

    positions
    |> validPositions
    |> List.map (fun pos -> (pos, scoreFunc pos))
    |> List.sortBy snd
    |> List.head
    |> fst
    |> scoreFunc

let Part1 input =
    input
    |> parseInput
    |> findOptimalUsage onlyGivenPositions (calculateFuelCost fuelForPart1)

let Part2 input =
    input
    |> parseInput
    |> findOptimalUsage allPositionsBetween (calculateFuelCost fuelForPart2)
