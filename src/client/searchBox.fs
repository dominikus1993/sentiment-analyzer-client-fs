[<RequireQualifiedAccess>]
module SearchBox
open System
open Fable.Core
open Fable.Core.JsInterop
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type Request = { Text: string option }
type Handler = { Handler: string -> unit }

type SearchBox(props) as this =
    inherit React.Component<Handler, Request>(props)
    do this.state <- {Text = None}

    member x.handleTextChange(e: React.SyntheticEvent) =
        let text = unbox e.target?value
        x.setState { x.state with Text = Some text }

    member x.handleSubmit(e: React.SyntheticEvent) =
        e.preventDefault()
        match x.state with
        | { Text = Some(value) } -> 
                    x.props.Handler value
                    x.setState { x.state with Text = Some "" }
        | _ -> ()
        
    member x.render() =
        R.form[
            P.ClassName "searchBox"
            P.OnSubmit x.handleSubmit
            ] [
                R.input[
                    P.Type "text"
                    P.Placeholder "Wpisz szukana fraze"
                    P.Value (U2.Case1 x.state.Text.Value)
                    P.OnChange x.handleTextChange
                    ][]
                R.input[
                    P.Type "submit"
                    P.Value (U2.Case1 "Post")
                    ][]
            ]