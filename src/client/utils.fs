module Utils
open Dto

let countSentiment (tweets: Tweet []) =
    printf "%A" tweets
    match tweets with 
    | [||] -> 
        0
    | tweetsArray ->
        let arr = tweetsArray |> Seq.ofArray
        let sum = arr |> Seq.fold(fun acc x -> acc + x.Sentiment) 0
        let count = arr |> Seq.length
        sum / count