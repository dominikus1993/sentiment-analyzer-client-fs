[<RequireQualifiedAccess>]
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

type Result = {data: Tweet[]}