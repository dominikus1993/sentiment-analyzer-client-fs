module Utils
open Dto

let countSentiment (tweets: Tweet []) =
    match tweets with 
    | [||] -> 
        0.0
    | tweetsArray ->
        let arr = tweetsArray |> Seq.ofArray
        let sum = arr |> Seq.fold(fun acc x -> acc + x.Sentiment) 0
        let count = arr |> Seq.length
        double (sum / count)

let getImgBySentiment = function
    | n when n < 0.0 -> "sad.png"
    | n when n = 0.0 -> "neutral.png"
    | n when n > 0.0 -> "happy.png"
    | _ -> "neutral.png"