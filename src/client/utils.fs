[<RequireQualifiedAccess>]
module Utils

let countSentiment (tweets: Dto.Tweet[]) =
    match tweets with 
    | [||] -> 0
    | tweets ->
        let sum = tweets |> Array.sumBy(fun x -> x.Sentiment)
        let count = tweets |> Array.length
        sum / count