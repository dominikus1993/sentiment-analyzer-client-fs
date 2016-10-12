module TweetTextInput
open System
open Fable.Core
open Fable.Import
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type ITweetTextInputProps =
    abstract OnSave: string->unit
    abstract Text: string option
    abstract Placeholder: string
    abstract Search: bool

type TweetTextInputState = { Text: string }

type TweetTextInput(props, ctx) as this = 
    inherit React.Component<ITweetTextInputProps, TweetTextInputState>(props, ctx)
    do this.state <- { Text = defaultArg this.props.Text "" }

    member this.render() =
        R.h1 [] [unbox "Hello world"]
        
