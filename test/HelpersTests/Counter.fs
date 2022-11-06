module HelperTests.Counter

open System
open Xunit
open Helpers

[<Fact>]
let ``Empty Counter is Empty List`` () =
    let counter = Counter.createCounter ()
    Assert.Equal<(int * uint64) list>([], counter)

[<Fact>]
let ``Adding single value to counter works correctly and is immutable`` () =
    let counter = Counter.createCounter ()
    Assert.Equal<(int * uint64) list>([], counter)

    let added1 = Counter.addSingle 1 counter
    Assert.Equal<(int * uint64) list>([ (1, 1UL) ], added1)

    let added2 = Counter.addSingle 1 added1
    Assert.Equal<(int * uint64) list>([ (1, 2UL) ], added2)

    // Check if still immutable
    Assert.Equal<(int * uint64) list>([], counter)

[<Fact>]
let ``Adding multiple values to counter works correctly`` () =
    let counter = Counter.createCounter ()
    Assert.Equal<(int * uint64) list>([], counter)

    let counter = Counter.add 1 5UL counter
    Assert.Equal<(int * uint64) list>([ (1, 5UL) ], counter)

    let counter = Counter.addSingle 1 counter
    Assert.Equal<(int * uint64) list>([ (1, 6UL) ], counter)
