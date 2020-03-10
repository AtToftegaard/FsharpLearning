module Util

open System

let Swap (arr: int[]) x y  =
    let temp = arr.[x]
    arr.[x] <- arr.[y]
    arr.[y] <- temp

let PrintArray title (arr: int[]) = 
    printf "\n %s \n %s \n" title (String.replicate 10 "-") 
    for i = 0 to arr.Length-1 do
        Console.WriteLine arr.[i]
    arr

let rand = new System.Random()    
let Shuffle (a: int[]) =
    [0..(a.Length-2)] 
    |> Seq.iter(fun i -> Swap a i (rand.Next(0, Array.length a)))
    a