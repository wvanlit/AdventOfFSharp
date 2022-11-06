module Advent2021.Days.Day6

open System
open Helpers

let puzzle = PuzzleInput.load 2021 6 PuzzleInput.Type.Puzzle

type LanternFishLifetime = int
type LanternFishCount = (int * uint64)
type LanternFishSchool = Counter.Counter<LanternFishLifetime>

let fishLifetime: LanternFishLifetime = 6
let newFishLifetime: LanternFishLifetime = 9 // Will tick down during spawn day, so actually 8

let parseInput (input: string) : LanternFishSchool =
    let fish = input.Split "," |> Array.map int |> Array.toList

    let fishCount lifetime =
        fish |> List.filter (fun f -> f = lifetime) |> List.length |> uint64

    let lifetimes = [ 0..newFishLifetime ]
    let totalFishes = lifetimes |> List.map fishCount

    List.zip [ 0..newFishLifetime ] totalFishes

let tick (count: LanternFishCount) =
    let (lifetime, total) = count
    let next = if lifetime = 0 then fishLifetime else lifetime - 1
    (next, total)

let isEndOfCycle fish = fish = 0uy

let spawn (school) =
    let totalEndOfCycle = List.tryFind (fun (lifetime, _) -> lifetime = 0) school

    match totalEndOfCycle with
    | Some (_, total) -> Counter.add newFishLifetime total school
    | None -> school


let merge (school: LanternFishSchool) : LanternFishSchool =
    school
    |> List.groupBy fst
    |> List.map (fun (lifetime, all) ->
        let total = List.fold (fun current (_, total) -> current + total) 0UL all
        (lifetime, total))
    |> List.sortBy fst

let passDay school =
    school |> spawn |> List.map tick |> merge

let rec simulateDays days school =
    if days = 0 then
        school
    else
        simulateDays (days - 1) (passDay school)

let sumFish school = school |> List.map snd |> List.sum

let Part1 input =
    input |> parseInput |> simulateDays 80 |> sumFish

let Part2 input =
    input |> parseInput |> simulateDays 256 |> sumFish
