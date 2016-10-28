module Trend
open System
open Fable.Core
open Fable.Core.JsInterop
open Dto
open Utils
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

module TrendUtils =

    type Trend =
        | Decreasing of string
        | Increasing of string
        | Stable of string
    let private aritmeticAverageT t = 
        let elementsQuantity = t |> Array.length |> float
        let sum =  t |> Array.sum
        sum / float elementsQuantity

    let private aritmeticAverageY(y: int[]) = 
        let elementsQuantity = y |> Array.length |> float
        let sum =  y |> Array.sum |> float
        sum / float elementsQuantity

    let countA (tweets: Tweet[]) =
        let t = [|1.0..(tweets |> Array.length |> float)|]
        let y = tweets |> Array.map(fun tweet -> tweet.Sentiment)
        let averageT = aritmeticAverageT(t)
        let averageY = aritmeticAverageY(y)
        let tmta = t |> Array.map(fun x -> x - averageT)
        let ymya = y |> Array.map(fun x -> (x |> float) - averageY)
        let numerator = tmta |> Array.zip(ymya) |> Array.map(fun (x,y) -> x * y) |> Array.sum
        let denominator = tmta |> Array.map(fun x -> x ** 2.0) |> Array.sum
        numerator / denominator
    let rateTrend = function
        | 0.0 -> Stable("Stabliny")
        | num when num > 0.0 -> Increasing("Rosnacy")
        | num when num < 0.0 -> Decreasing("Malejacy")
        | _ -> Stable("Stabilny")

type TrendComponent(props) =
    inherit React.Component<Tweets, obj>(props)

    member x.trendImg() =
        if (x.props.data |> Array.length) <> 0 then  
            let trend = TrendUtils.countA(x.props.data) |> TrendUtils.rateTrend
            match trend with 
            | TrendUtils.Trend.Decreasing(x) -> x
            | TrendUtils.Trend.Increasing(x) -> x
            | TrendUtils.Trend.Stable(x) -> x
        else 
            "Stabilny"

    member x.render () =
        R.div [ P.ClassName "trend-img" ] [unbox (x.trendImg())]
        