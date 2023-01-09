open System
open ChartingBasics
open Plotly.NET

open Plotly.NET.Interactive
//for heatmap
open FSharp.Stats.Distributions

[<EntryPoint>]
let main _ =
    // call a .NET method that takes a parameter array, passing values of various types
    let chart = new BasicCharts()
    let statusCode = 0
    let plotType = "heatmap2D"

    // Pattern matching
    let chartFilter x =
        match x with
        | "bar" -> //Bar
            //Plot
            statusCode = chart.simpleBarChart

        | "scatter" -> //Scatter
            let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
            let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]
            let labels = [ "a"; "b"; "c"; "d"; "e"; "f"; "g"; "h"; "i"; "j" ]
            //Plot
            let chart = new BasicCharts(x = x, y = y)
            statusCode = chart.simpleScatterChart (labs = labels)

        | "boxPlot" -> //BoxPlot
            let x = [ 1.; 2.; 3.; 4.; 5. ]
            let y = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
            //Plot
            //statusCode = chart.simpleBoxPlot (x = x, y = y)
            statusCode = chart.simpleBoxPlot (x = x, y = y)

        | "heatmap2D" -> //2DHistogram
            let xs =
                let normal = Continuous.Normal.Init 500. 20.
                [ 300.0 .. 700.0 ] |> Seq.map (fun x -> normal.Sample())

            let ys =
                let normal = Continuous.Normal.Init 500. 20.
                [ 300.0 .. 700.0 ] |> Seq.map (fun x -> normal.Sample())

            //Plot
            statusCode = chart.simpleHeatmap (xs = xs, ys = ys)

    chartFilter plotType

    //Console.WriteLine("Status: {0}", rc),
    let sc = statusCode
    printfn "Status: %d " sc
    sc //Status code on exit
