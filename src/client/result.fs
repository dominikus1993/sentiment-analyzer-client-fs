[<RequireQualifiedAccess>]
module Result
open System
open Fable.Core
open Fable.Core.JsInterop
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props


type SearchBox(props) as this =
    inherit React.Component<Tweet list, Request>(props)
    do this.state <- {Text = None}
