
[<RequireQualifiedAccess>]
module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

let handler query = 
    let url = sprintf "http://localhost:8083/analyze/%s" query
    do printf "%A" url
    ()

type App(props) = 
    inherit React.Component<obj,obj>(props)

    member this.render () = 
        let form = R.com<SearchBox.SearchBox,_,_> {Handler = handler} []
        let box = R.com<Result.ResultBox, _, _> [] []
        R.div [P.ClassName "app"] [form; box] 