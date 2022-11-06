module Advent2021Tests.Days.Day6

open Advent2021.Days.Day6
open Helpers
open Xunit

let example = PuzzleInput.load 2021 6 PuzzleInput.Type.Example
let puzzle = PuzzleInput.load 2021 6 PuzzleInput.Type.Puzzle

[<Fact>]
let ``Ticks fish correctly`` () =
    Assert.Equal((fishLifetime, 1UL), tick (0, 1UL))
    Assert.Equal((0, 1UL), tick (1, 1UL))
    Assert.Equal((1, 1UL), tick (2, 1UL))
    Assert.Equal((2, 1UL), tick (3, 1UL))

[<Fact>]
let ``Spawns fish correctly`` () =
    Assert.Equal<LanternFishCount list>([ (1, 1UL) ], spawn [ (1, 1UL) ])
    Assert.Equal<LanternFishCount list>([ (0, 1UL); (newFishLifetime, 1UL) ], spawn [ (0, 1UL) ])

[<Fact>]
let ``Passed day correctly`` () =
    Assert.Equal<LanternFishCount list>([ (0, 1UL); (1, 1UL); (2, 1UL) ], passDay [ (1, 1UL); (2, 1UL); (3, 1UL) ])
    Assert.Equal<LanternFishCount list>([ (0, 2UL); (6, 3UL); (8, 3UL) ], passDay [ (0, 3UL); (1, 2UL) ])

[<Fact>]
let ``Day 6.1 - Example`` () = Assert.Equal(Part1 example, 5934UL)

[<Fact>]
let ``Day 6.1 - Puzzle`` () = Assert.Equal(Part1 puzzle, 356190UL)

[<Fact>]
let ``Day 6.2 - Example`` () =
    Assert.Equal(Part2 example, 26984457539UL)

[<Fact>]
let ``Day 6.2 - Puzzle`` () = Assert.Equal(Part2 puzzle, 1617359101538UL)
