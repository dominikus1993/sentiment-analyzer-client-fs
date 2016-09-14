
[<RequireQualifiedAccess>]
module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type App(props) as this= 
    inherit React.Component<obj,Dto.Result>(props)
    do this.state <- {data = [||]}

    member x.handleSearchBoxQuery (query: string) =
       let url = sprintf "http://localhost:8083/analyze/%s" query
       do printf "%A" url
       this.setState { this.state with data = [|{IdStr = "1"; Text = "Test"; Key = "Key"; Date = System.DateTime.Now; Lang = "En"; Longitude = 1.1; Latitude = 1.1; Sentiment = 10}|]}
       () 

    member x.render () = 
        let form = R.com<SearchBox.SearchBox,_,_> {Handler = this.handleSearchBoxQuery} []
        let box = R.com<Result.ResultBox, _, _> this.state.data []
        R.div [P.ClassName "app"] [form; box] 