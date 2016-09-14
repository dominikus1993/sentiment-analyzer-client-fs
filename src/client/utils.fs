[<RequireQualifiedAccess>]
module Utils

let countSentiment (tweets: Dto.Tweet list) =
    match tweets with 
    | [] -> 0
    | head::tail ->
        let sum = head::tail |> List.fold(fun acc x -> acc + x.Sentiment) 0
        let count = head::tail |> List.length
        sum / count