module Trend
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

module TrendUtils =
    let assignTrend(tweets: Tweets) =   
        2

type TrendComponent(props) =
    inherit React.Component<Tweets, obj>(props)
    member x.render () =
        R.div [ P.ClassName "score" ] []
        