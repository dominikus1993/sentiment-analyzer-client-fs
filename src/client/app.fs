
[<RequireQualifiedAccess>]
module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type App(props) = 
    inherit React.Component<obj,obj>(props)

    member this.render () = 
        R.div [P.ClassName "app"] [R.h1[] [unbox "Hello World"]]