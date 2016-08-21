[<RequireQualifiedAccess>]
module Ajax
open System
open Fable.Core
open Fable.Import
open Fable.Import.Browser

type HttpMethod<'a> = 
    | Get of url: string
    | Post of url: string * data: 'a

let buildRequestUrl domain req =
    sprintf "%s/%s" domain req


let ajax meth onSuccess onError =
    let url, http, data =
        match meth with
        | Get url -> url, "GET", None
        | Post (url, data) -> url, "POST", Some(JS.JSON.stringify data)
    
    let req = XMLHttpRequest.Create()

    req.onreadystatechange <- fun _ ->
       match req.readyState with
       | 4. when req.status = 200. || req.status = 0. -> JS.JSON.parse req.responseText |> unbox |> onSuccess
       | 4. -> req.statusText |> onError
       | _ -> null
    
    req.``open``(http, url, true)
    req.send(data)