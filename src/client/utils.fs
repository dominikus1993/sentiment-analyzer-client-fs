[<RequireQualifiedAccess>]
module Utils

let countSentiment (tweets: Dto.Tweet []) =
    printf "%A" tweets
    match tweets with 
    | [||] -> 
        printf "Empty"
        0
    | tweetsArray ->
        printf "Not Empty %A" (tweets |> Array.length)
        let sum = tweetsArray |> Array.fold(fun acc x -> acc + x.Sentiment) 0
        let count = tweetsArray |> Array.length
        sum / count