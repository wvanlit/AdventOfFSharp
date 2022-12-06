module Advent2022.Days.Day6

let findIndexOfNonRecurring n (input: string) =
    input.ToCharArray ()
    |> Array.windowed n
    |> Array.map Set.ofArray
    |> Array.findIndex (fun set -> Set.count set = n)
    |> fun index -> index + n

let Part1 input = findIndexOfNonRecurring 4 input

let Part2 input = findIndexOfNonRecurring 14 input
