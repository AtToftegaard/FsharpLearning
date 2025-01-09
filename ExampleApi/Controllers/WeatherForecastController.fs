namespace ExampleApi.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open ExampleApi
open UseCaseResult

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let summaries =
        [|
            "Freezing"
            "Bracing"
            "Chilly"
            "Cool"
            "Mild"
            "Warm"
            "Balmy"
            "Hot"
            "Sweltering"
            "Scorching"
        |]

    [<HttpGet>]
    member _.Get() =
        let rng = System.Random()
        [0..4] |> List.map (fun index ->
            { Date = DateTime.Now.AddDays(float index)
              TemperatureC = rng.Next(-20,55)
              Summary = summaries.[rng.Next(summaries.Length)] })

    [<HttpGet("{daysAhead}")>]
    member _.Get(daysAhead : int) =

        let bind switchFunction = 
            fun twoTrackInput -> 
                match twoTrackInput with
                | Success s -> switchFunction s
                | Failure f -> Failure f

        let notNull input =
            if input < 0 then
                Failure "Days ahead must be a positive number"
            else
                Success input

        let notTooFarAhead input =
            if input > 5 then
                Failure "Days ahead must be less than or equal to 5"
            else
                Success input

        let combined =
            let validate = bind notNull
            let validate2 = bind notTooFarAhead
            validate >> validate2

        let rng = System.Random()
        { Date = DateTime.Now.AddDays(float daysAhead)
          TemperatureC = rng.Next(-20,55)
          Summary = summaries.[rng.Next(summaries.Length)] }