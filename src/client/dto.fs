module Dto
open System

type Tweet = {IdStr : string
              Text : string
              Key : string
              Date : DateTime
              Lang : string
              Longitude : double
              Latitude : double
              Sentiment : int}

type TweetAction = 
    | GetRandomStatistics of int
    | Search of string

let [<Literal>] ESCAPE_KEY = 27.
let [<Literal>] ENTER_KEY = 13.

type Tweets = { data: Tweet[]; dispatch: TweetAction -> unit }

type Result = { value: Tweet[]; isSuccess: bool; messages: string[] }

type KeyBySentimentValue = { key: string; value: double }

let classNames =
    List.choose (fun (text, add) -> if add then Some text else None) >> String.concat " "