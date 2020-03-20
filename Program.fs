// Learn more about F# at http://fsharp.org

open System
open Util

[<EntryPoint>]
let main argv =
    
    let mutable swapCount = 0
    let mutable swapHistory = Array2D.init
    let a = Array2D.init 10 10 (fun x y -> 0)
    
    let rec BubbleSort (arr: int array) = 
        for i = 0 to arr.Length-2 do
            if arr.[i] > arr.[i+1] then
                swapCount <- swapCount+1
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

