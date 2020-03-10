// Learn more about F# at http://fsharp.org

open System
open Util

[<EntryPoint>]
let main argv =
    
    let rec BubbleSort (arr: int[]) = 
        for i = 0 to arr.Length-2 do
            if arr.[i] > arr.[i+1] then
                Swap arr i (i+1)
                BubbleSort arr
    
    let array = [| 1 .. 10 |]
                |> Shuffle
                |> PrintArray "UNSORTED:"
    
    BubbleSort array

    PrintArray "SORTED:" array  |> ignore
    
    0 // return an integer exit code

  //  let rec sort (a: int []) =
  //  let mutable fin = true
  //  for i in 0..a.Length-2 do
  //  if a.[i] > a.[i+1] then
  //    let t = a.[i]
  //    a.[i] <- a.[i+1]
  //    a.[i+1] <- t
  //    fin <- false
  //if not fin then sort a

