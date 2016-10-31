module App
open System
open Fable.Core
open Fable.Import
open Dto
open Score
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type AppProps = { Store: Redux.IStore<Tweet[], TweetAction>}

type AppComponent(props) as this= 
    inherit React.Component<AppProps, Tweets>(props)   
    let dispatch = Redux.dispatch props.Store
    let getState() = { data = Redux.getState props.Store; dispatch = dispatch}
    do this.state <- getState()
    member x.handleSearchBoxQuery (query: string) =
       let url = Ajax.buildRequestUrl Constants.apiUrl query
       //Ajax.request (Ajax.Get url) (fun items -> x.setState({ data = items})) (fun status -> Browser.console.error(status))
       () 

    member x.render () = 
        let form = R.com<SearchBox.SearchBoxComponent,_,_> { Search = Search >> dispatch } []
        let box = R.com<ScoreComponent, _, _> x.state []
        R.div [P.ClassName "container"] [form; box] 