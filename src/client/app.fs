module App
open System
open Fable.Core
open Fable.Import
open Dto
open Score
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type AppComponent(props) as this= 
    inherit React.Component<obj,Dto.Sentiments>(props)
    do this.state <- { data = [||] }

    member x.handleSearchBoxQuery (query: string) =
       let url = Ajax.buildRequestUrl Constants.apiUrl query
       Ajax.request (Ajax.Get url) (fun items -> x.setState({ data = items})) (fun status -> Browser.console.error(status))
       () 

    member x.render () = 
        let form = R.com<SearchBox.SearchBoxComponent,_,_> {Search = x.handleSearchBoxQuery} []
        let box = R.com<ScoreComponent, _, _> x.state []
        R.div [P.ClassName "container"] [form; box] 