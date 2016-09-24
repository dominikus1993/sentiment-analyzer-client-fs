module Emotion
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props


type EmotionBox(props) =
    inherit React.Component<Sentiment, obj>(props)

    member x.render () =
        let img = getImgBySentiment(x.props.Sentiment)
        let result = R.img [ P.Src img ] []
        R.div [] [ result ]