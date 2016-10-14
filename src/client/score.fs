module Score
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
open Emotion
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props


type ScoreComponent(props) =
    inherit React.Component<Sentiments, obj>(props)

    member x.render () =
        let sentiment = { Value = countSentiment(x.props.data) }
        printf "%A" sentiment
        let box = R.com<Emotion.EmotionTextComponent, _, _> sentiment []
        R.div [ P.ClassName "Result" ] [box]