[<RequireQualifiedAccess>]
module SearchBox
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
                    member __.Placeholder = "Wpisz szukaną fraze"
                    member __.Search = true
                } []
        let form = R.div[P.ClassName "form-group"] [
                        textInput
                        R.input[
                            P.Type "submit"
                            P.Value (U2.Case1 "Post")
                            ][]
                    ]
        R.div[P.ClassName "form-inline"][form]