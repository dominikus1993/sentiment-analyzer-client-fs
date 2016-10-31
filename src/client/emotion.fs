module Emotion
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type EmotionProps = { Value: double; }

let private getEmotionText = function
    | num when num < 0.0 -> "NEGATYWNY"
    | num when num > 0.0 -> "POZYTWNY"
    | num when num = 0.0 -> "NEUTRALNY"
    | _ -> "NEUTRALNY"

type EmotionTextComponent(props) =
    inherit React.Component<EmotionProps, obj>(props)

    member x.render () =
        let text = R.h1 [P.ClassName ""] [unbox (getEmotionText x.props.Value)]
        text

type EmotionValueComponent(props) =
    inherit React.Component<EmotionProps, obj>(props)

    member x.render () =
        let text = R.h1 [P.ClassName ""] [unbox (x.props.Value.ToString())]
        text