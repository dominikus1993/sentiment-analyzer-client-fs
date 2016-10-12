module TweetTextInput
open System
open Fable.Core
open Fable.Core.JsInterop
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

    member this.HandleSubmit(e: React.KeyboardEvent) =
        if e.which = Dto.ENTER_KEY then
            let text = (unbox<string> e.target?value).Trim()
            this.props.OnSave(text)
            if this.props.Search then
                this.setState({ Text = "" })
    member this.render() =
        R.h1 [] [unbox "Hello world"]
        
