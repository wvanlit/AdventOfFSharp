module Advent2022.Days.Day2

open Helpers

type HandShape =
    | Rock
    | Paper
    | Scissors

type Outcome =
    | Win
    | Loss
    | Draw

let mapHand input : HandShape =
    match input with
    | "A"
    | "X" -> Rock
    | "B"
    | "Y" -> Paper
    | "C"
    | "Z" -> Scissors
    | _ -> failwith "Invalid state"

let mapDesiredOutcome input : Outcome =
    match input with
    | "X" -> Loss
    | "Y" -> Draw
    | "Z" -> Win
    | _ -> failwith "Invalid state"

let mapHands mapFunc (list: string []) =
    list
    |> Array.map (fun s -> s.Split " ")
    |> Array.map mapFunc
    |> Array.toList

let parseInput (input: string) = input |> PuzzleInput.trimAndSplit

let getOutcome (opponent: HandShape) (yours: HandShape) =
    if yours = opponent then
        Draw
    else
        match yours with
        | Rock -> if opponent = Scissors then Win else Loss
        | Paper -> if opponent = Rock then Win else Loss
        | Scissors -> if opponent = Paper then Win else Loss

let getHandForOutcome (opponent: HandShape) (outcome: Outcome) =
    match outcome with
    | Draw -> opponent
    | Loss ->
        match opponent with
        | Rock -> Scissors
        | Paper -> Rock
        | Scissors -> Paper
    | Win ->
        match opponent with
        | Rock -> Paper
        | Paper -> Scissors
        | Scissors -> Rock

let score (hand: HandShape) (outcome: Outcome) =
    let handScore =
        match hand with
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3

    let outcomeScore =
        match outcome with
        | Win -> 6
        | Draw -> 3
        | Loss -> 0

    handScore + outcomeScore

let Part1 input =
    input
    |> parseInput
    |> mapHands (fun [| opponent; yours |] -> (mapHand opponent, mapHand yours))
    |> List.map (fun (opponent, yours) -> score yours (getOutcome opponent yours))
    |> List.sum

let Part2 input =
    input
    |> parseInput
    |> mapHands (fun [| opponent; desired |] -> (mapHand opponent, mapDesiredOutcome desired))
    |> List.map (fun (opponent, desired) -> score (getHandForOutcome opponent desired) desired)
    |> List.sum
