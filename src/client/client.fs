module Client
open System
open Fable.Core
open Fable.Import

module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

Node.require.Invoke("core-js") |> ignore
Node.require.Invoke("bootstrap/dist/css/bootstrap.css") |> ignore

let model = new Object()
ReactDom.render(R.com<App.App,_,_> model [], Browser.document.getElementById("container")) |> ignore