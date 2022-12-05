module Helpers.PuzzleInput

open System.IO
open Microsoft.FSharp.Collections

type Type =
    | Puzzle
    | Example

let splitOnNewlines (s: string) = s.Split "\r\n"

let trimAndSplit (s: string) = s.Trim () |> splitOnNewlines

let getInputDir =
    let mutable dir: DirectoryInfo =
        Directory.GetParent (Directory.GetCurrentDirectory ())

    while dir.GetDirectories ()
          |> Array.exists (fun (d: DirectoryInfo) -> d.Name = "inputs")
          |> not do
        dir <- Directory.GetParent dir.FullName

    dir.FullName

let load year day inputType =
    let suffix =
        match inputType with
        | Puzzle -> "puzzle"
        | Example -> "example"

    [| getInputDir; "inputs"; year.ToString (); $"{day}_{suffix}.txt" |]
    |> Path.Join
    |> File.ReadAllText
