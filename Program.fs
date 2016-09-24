// Learn more about F# at http://fsharp.org
namespace ChynoSurf
open System

module Program =
    [<EntryPoint>]
    let main argv = 
        printfn "Hello World!"
        argv 
        |> Array.map int
        |> Array.map Lib.g
        |> Array.iter (printf "Valueis : %i \n")
        0 // return an integer exit code
