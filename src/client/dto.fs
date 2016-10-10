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

type Result = { value: Tweet[]; isSuccess: bool; messages: string[] }

type Sentiments = { data: Tweet[] }

type Sentiment = { Sentiment: double }

type KeyBySentimentValue = { key: string; value: double }