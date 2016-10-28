module Score
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
open Emotion
open Trend
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type ScoreComponent(props) =
    inherit React.Component<Tweets, obj>(props)

    member x.render () =
        let sentiment = { Value = countSentiment(x.props.data) }
        let text = R.div [P.ClassName "text" ] [R.com<Emotion.EmotionTextComponent, _, _> sentiment []]
        let value = R.div [P.ClassName "value" ] [R.com<Emotion.EmotionValueComponent, _, _> sentiment []]
        let trend = R.div[P.ClassName "trend"] [R.com<TrendComponent, _, _> x.props []]
        R.div [ P.ClassName "score" ] [text; value; trend]