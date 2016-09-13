[<RequireQualifiedAccess>]
module Utils

let countSentiment (tweets: Dto.Tweet list) =
    match tweets with 
    | [] -> 0
    | tweets ->
        let sum = tweets |> List.sumBy(fun x -> x.Sentiment)
        let count = tweets |> List.length
        sum / count