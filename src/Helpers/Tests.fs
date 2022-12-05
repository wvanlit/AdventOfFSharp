module Helpers.Tests

type Part<'T> = {
    Example: 'T
    Puzzle: 'T
}

type TestInput<'T> = {
    Part1: Part<'T>
    Part2: Part<'T>
}
