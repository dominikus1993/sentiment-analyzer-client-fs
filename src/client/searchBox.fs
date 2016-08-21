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
    
    member x.handleQueryTextChange(e: React.SyntheticEvent) =
        let q = unbox e.target
        x.setState {x.state with Text = q}

    member x.handleSubmit(e: React.SyntheticEvent) =
        printf "dupa"

    member x.render() =
        R.form[
            P.ClassName "searchBox"
            P.OnSubmit x.handleSubmit
            ] [
                R.input[
                    P.Type "text"
                    P.Placeholder "Wpisz szukana fraze"
                    P.Value (U2.Case1 x.state.Text.Value)
                    P.OnChange x.handleQueryTextChange
                    ][]
                R.input[
                    P.Type "submit"
                    P.Value (U2.Case1 "Post")
                    ][]
            ]