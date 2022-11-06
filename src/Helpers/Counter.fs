module Helpers.Counter

type Counter<'a> = ('a * uint64) list

let createCounter () : Counter<'a> = []

let from (x: ('a * uint64) list) : Counter<'a> = x

let fromList (x: 'a list) : Counter<'a> =
    x
    |> List.groupBy id
    |> List.map (fun (value, list) -> (value, uint64 (List.length list)))

let add (x: 'a) (amount: uint64) (counter: Counter<'a>) : Counter<'a> =
    let existing = List.tryFind (fun (_, t) -> fst t = x) (List.indexed counter)

    match existing with
    | Some (idx, (v, count)) -> List.updateAt idx (v, count + amount) counter
    | None -> List.append counter [ (x, amount) ]

let addSingle value counter = add value 1UL counter
