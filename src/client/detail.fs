module Detail
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
open Trend
open Best
open Worst
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type DetailComponent(props) =
    inherit React.Component<Tweets, obj>(props)

    member x.render () =
        let trend = R.div[P.ClassName "col-md-4"] [R.com<TrendComponent, _, _> x.props []]
        let best = R.div[P.ClassName "col-md-4"] [R.com<WorstScoreComponent, _, _> x.props []]
        let worst = R.div[P.ClassName "col-md-4"] [R.com<BestScoreComponent, _, _> x.props []]
        
        R.div [ P.ClassName "row" ] [best; trend; worst]