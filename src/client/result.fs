[<RequireQualifiedAccess>]
module Result
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props


type ResultBox(props) =
    inherit React.Component<Tweet[], obj>(props)

    member this.render () =
        R.h1 [] [ unbox (countSentiment(this.props)) ]