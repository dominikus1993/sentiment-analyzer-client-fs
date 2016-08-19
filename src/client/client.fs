module Client
open System
open Fable.Core
open Fable.Import

module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

let model = new Object()
ReactDom.render(R.com<App.App,_,_> model [], Browser.document.getElementById("content")) |> ignore