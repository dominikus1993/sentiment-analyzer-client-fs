module Client
open System
open Fable.Core
open Fable.Import
open App
open Dto
open Reducers
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

Node.require.Invoke("core-js") |> ignore
Node.require.Invoke("bootstrap/dist/css/bootstrap.css") |> ignore

let store =
    [|{IdStr = "1"; Text = "Elo"; Key = "fsharp"; Date = DateTime.Now; Lang = "En"; Longitude = 1.2; Latitude = 1.3; Sentiment = 22}|]
    |> Redux.createStore tweetReducer

ReactDom.render(
        R.com<App.AppComponent,_,_> { Store = store } [], Browser.document.getElementById("container")
    ) |> ignore