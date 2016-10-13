module TweetTextInput
open Dto
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type ITweetTextInputProps =
    abstract OnSearch: string->unit
    abstract Text: string option
    abstract Placeholder: string
    abstract Search: bool

type TweetTextInputState = { Text: string }

type TweetTextInputComponent(props, ctx) as this = 
    inherit React.Component<ITweetTextInputProps, TweetTextInputState>(props, ctx)
    do this.state <- { Text = defaultArg this.props.Text "" }

    member this.HandleSubmit(e: React.KeyboardEvent) =
        if e.which = Dto.ENTER_KEY then
            let text = (unbox<string> e.target?value).Trim()
            this.props.OnSearch(text)
            if this.props.Search then
                this.setState({ Text = "" })

    member this.HandleChange(e: React.SyntheticEvent) =
        this.setState({ Text = unbox e.target?value })
    
    member this.HandleBlur(e: React.SyntheticEvent) =
        if not this.props.Search then
            this.props.OnSearch(unbox e.target?value)
    member this.render() =
        R.input [
            P.ClassName (classNames [("input-lg", true); ("form-control", true)])
            P.Type "text"
            P.OnBlur this.HandleBlur
            P.OnChange this.HandleChange
            P.OnKeyDown this.HandleSubmit
            P.AutoFocus (this.state.Text.Length > 0)
            P.Placeholder this.props.Placeholder
            ] []
        
