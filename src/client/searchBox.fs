[<RequireQualifiedAccess>]
module SearchBox
open Dto
open System
open TweetTextInput
open Fable.Core
open Fable.Core.JsInterop
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type SearchBoxProps = { Search: string -> unit }

type SearchBoxComponent(props) as this =
    inherit React.Component<SearchBoxProps, obj>(props)

    member x.render() =
        let textInput = 
            R.com<TweetTextInputComponent,_,_> 
                { new ITweetTextInputProps with
                    member __.OnSearch(text: string) =
                        if text.Length <> 0 then
                            this.props.Search text
                    member __.Text = None
                    member __.Placeholder = "Wpisz fraze"
                    member __.Search = true
                } []

        let button = R.input[
                            P.ClassName (classNames [("btn", true); ("btn-default", true); ("btn-lg", true)])
                            P.Type "submit"
                            P.Value (U2.Case1 "Szukaj")
                            ][]

        let form = R.div[P.ClassName (classNames [("input-group", true); ("input-group-lg", true)])] [
                        textInput
                        R.span [P.ClassName "input-group-btn"] [button]
                    ]
        let inputGroup = R.div[P.ClassName "col-lg-12"][form]
        R.div [P.ClassName "row"] [inputGroup]        