module Reducers
open Dto
let tweetReducer(state: Tweet[]) = function
    | Search(query: string) ->
        state
    | GetRandomStatistics(quantity) -> 
        state