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

    member x.render () =
        R.div [ P.ClassName "score" ] []