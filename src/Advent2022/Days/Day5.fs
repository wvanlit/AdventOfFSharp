module Advent2022.Days.Day5

open FSharpAux
open Helpers

type MoveCommand = { amount: int; from: int; towards: int }

let parseInput (input: string) =
    let [| boxInput; commandInput |] =
        input.Split "\r\n\r\n" |> Array.map PuzzleInput.splitOnNewlines

    let lastItem = Array.length boxInput - 1

    let (boxes, indices) =
        (boxInput[0 .. lastItem - 1], boxInput[ lastItem ].Trim().Split " ")

    let numStacks = (Array.last >> int) indices

    let getCrateAt pos (str: string) =
        let index = pos * 4 + 1
        if str.Length < index then " " else str.Substring (index, 1)

    let cratesAtIndex i =
        boxes
        |> Array.map (getCrateAt i)
        |> Array.where (fun s -> s <> " ")
        |> Array.toList

    let stacks = List.init numStacks cratesAtIndex

    let commands =
        commandInput
        |> Array.where (fun s -> s <> "")
        |> Array.map (fun s -> s |> Regex.parse "move (\d+) from (\d+) to (\d+)" |> List.map int)
        |> Array.map (fun [ amount; from; towards ] -> { amount = amount; from = from - 1; towards = towards - 1 })
        |> Array.toList

    (stacks, commands)

let moveCrates reverseCrates (crateStacks: string list list) (commands: MoveCommand list) =
    let executeMove (stack: string list list) (command: MoveCommand) =
        let (payload, fromStack) = stack[command.from] |> List.splitAt command.amount

        let towardsStack =
            (if reverseCrates then payload |> List.rev else payload)
            @ stack[command.towards]

        stack
        |> List.updateAt command.from fromStack
        |> List.updateAt command.towards towardsStack

    let crates = List.fold executeMove crateStacks commands

    List.map List.head crates |> List.fold (fun s c -> s + c) ""

let Part1 input = input |> parseInput ||> moveCrates true

let Part2 input = input |> parseInput ||> moveCrates false
