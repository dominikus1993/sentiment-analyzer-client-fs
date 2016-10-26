module Worst
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type WorstScoreComponent(props) =
    inherit React.Component<Tweets, obj>(props)

    member x.GetWorst() = 
        let result = x.props.data |> Array.minBy(fun x -> x.Sentiment)
        (result.Sentiment, result.Date)

    member x.render () =
        let (sentiment, date) = x.GetWorst()
        let score = R.div[][ unbox (sentiment.ToString()) ]
        let date = R.div[][ unbox (date.ToString()) ]
        R.div [ P.ClassName "col-md-4" ] [ score; date ]