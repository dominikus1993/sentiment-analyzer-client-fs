module Button
open Dto
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
module React = Fable.Import.React
module R = Fable.Helpers.React
module P = Fable.Helpers.React.Props

type ButtonProps = { Value : string } 

type ButtonComponent(props, ctx) = 
    inherit React.Component<ButtonProps, obj>(props, ctx)
    
    member this.render() =
        R.input[
            P.ClassName (classNames [("btn", true); ("btn-default", true); ("btn-lg", true)])
            P.Type "submit"
            P.Value (U2.Case1 this.props.Value)
            ][]