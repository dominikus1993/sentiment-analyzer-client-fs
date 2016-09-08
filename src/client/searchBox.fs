[<RequireQualifiedAccess>]
module SearchBox
open System
open Fable.Core
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type Request = { Text: string option }
type Handler = { Handler: string -> unit }

type SearchBox(props) as this =
    inherit React.Component<Handler, Request>(props)
    do this.state <- {Text = None}

    member x.handleSubmit(e: React.SyntheticEvent) =
        printf "dupa"

    member x.render() =
        let inputPhrase = R.input [P.ClassName "phrase-input"; P.Type "text"; P.Ref (fun e -> x.setState {x.state with Text = Some(e.ToString())})][]
        let button = R.button [P.ClassName "send"; P.Type "submit"; P.Label "Send"; P.Value <| Case1 "Post"; P.OnMouseDown x.handleSubmit][]

        R.div [P.ClassName "twwetForm"][inputPhrase; button]