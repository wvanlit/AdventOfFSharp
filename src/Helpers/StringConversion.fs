module Helpers.StringConversion

let toStrList (str: string) =
    str.ToCharArray() |> Seq.map (fun x -> x.ToString()) |> Seq.toList
