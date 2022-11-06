module Advent2021.Solutions

open Advent2021.Days

let allDays () =
    [| ("1.1", Day1.Part1 Day1.puzzle)
       ("1.2", Day1.Part2 Day1.puzzle)
       ("2.1", Day2.Part1 Day2.puzzle)
       ("2.2", Day2.Part2 Day2.puzzle)
       ("3.1", Day3.Part1 Day3.puzzle)
       ("3.2", Day3.Part2 Day3.puzzle)
       ("4.1", Day4.Part1 Day4.puzzle)
       ("4.2", Day4.Part2 Day4.puzzle) |]
