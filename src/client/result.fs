[<RequireQualifiedAccess>]
module Result
open System
open Fable.Core
open Fable.Core.JsInterop
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props


type ResultBox(props) =
    inherit React.Component<Dto.Tweet list, obj>(props)

    member this.render () =
        R.h1 [] [ unbox (Utils.countSentiment(this.props)) ]

    
