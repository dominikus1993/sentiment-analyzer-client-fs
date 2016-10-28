module Best
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type BestScoreComponent(props) =
    inherit React.Component<Tweets, obj>(props)

    member x.GetBest() = 
        let result = x.props.data |> Array.maxBy(fun x -> x.Sentiment)
        (result.Sentiment, result.Date)

    member x.render () =
        let (sentiment, date) = x.GetBest()
        let header = R.h1[][unbox "Najlepszy wynik"]
        let score = R.div[][ unbox (sentiment.ToString()) ]
        let date = R.div[][ unbox (date.ToString()) ]
        R.div [ P.ClassName "best" ] [ header; score; date ]