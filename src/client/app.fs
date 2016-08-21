
[<RequireQualifiedAccess>]
module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

let handler query = 
    printf "%A" query

type App(props) = 
    inherit React.Component<obj,obj>(props)

    member this.render () = 
        let form = R.com<SearchBox.SearchBox,_,_> {Handler = handler} []
        R.div [P.ClassName "app"] [form]