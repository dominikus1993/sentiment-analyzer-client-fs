module Chart
open System
open Dto
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props
open D3

type ChartProps = { Store: Redux.IStore<Tweet[], TweetAction> }

type ChartComponent(props) as this =
    inherit React.Component<ChartProps, Tweets>(props)   
    let dispatch = Redux.dispatch props.Store
    let getState() = { data = Redux.getState props.Store; dispatch = dispatch}
    do this.state <- getState()

    member x.render () = 
        R.div [P.ClassName "chart"] [] 