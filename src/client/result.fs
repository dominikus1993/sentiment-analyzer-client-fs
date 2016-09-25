[<RequireQualifiedAccess>]
module Result
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
open Emotion
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props


type ResultBox(props) =
    inherit React.Component<Tweet[], obj>(props)

    member x.render () =
        let sentiment = { Sentiment = countSentiment(x.props) }
        printf "%A" sentiment
        let box = R.com<EmotionBox, _, _> sentiment []
        R.div [ P.ClassName "Result" ] [box]