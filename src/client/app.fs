
[<RequireQualifiedAccess>]
module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type App(props) as this= 
    inherit React.Component<obj,Dto.Result>(props)
    do this.state <- {data = []}

    member x.handleSearchBoxQuery (query: string) =
       let url = sprintf "http://localhost:8083/analyze/%s" query
       do printf "%A" url
       () 

    member x.render () = 
        let form = R.com<SearchBox.SearchBox,_,_> {Handler = x.handleSearchBoxQuery} []
        let box = R.com<Result.ResultBox, _, _> x.state.data []
        R.div [P.ClassName "app"] [form; box] 