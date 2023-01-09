namespace ChartingBasics

open System

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open Plotly.NET.Interactive
//for heatmap
open FSharp.Stats.Distributions

type BasicCharts(?x: float list, ?y: float list) =

    new() = BasicCharts(x = [], y = [])

    //
    member this.simpleBarChart: int =
        let xAxis =
            let tmp = LinearAxis()
            tmp?title <- "xAxis"
            tmp?zerolinecolor <- "#ffff"
            tmp?showline <- true
            tmp?zerolinewidth <- 2, tmp?gridcolor <- "ffff"
            tmp

        let yAxis =
            let tmp = LinearAxis()
            tmp?title <- "yAxis"
            tmp?zerolinecolor <- "#ffff"
            tmp?showline <- true
            tmp?zerolinewidth <- 2, tmp?gridcolor <- "ffff"
            tmp

        let trace =
            let tmp = Trace("bar")
            tmp?x <- [ 1; 2; 3 ]
            tmp?y <- [ 1; 3; 2 ]
            tmp

        let layout =
            let tmp = Layout()
            tmp?title <- "A Figure Specified by DynamicObj"
            tmp?plot_bgcolor <- "#e5ecf6"
            tmp?xaxis <- xAxis
            tmp?yaxis <- yAxis
            tmp?showlegend <- true
            tmp

        let plot =
            GenericChart.Figure.create [ trace ] layout
            |> GenericChart.fromFigure
            |> Chart.show

        88

    //
    member this.simpleScatterChart(?x: float list, ?y: float list, ?labs: string list) : int =

        let x = defaultArg x []
        let y = defaultArg y []
        let labs = defaultArg labs []

        let plot =
            Chart.Point(x, y, Name = "points", MultiText = labs, TextPosition = StyleParam.TextPosition.TopRight)
            |> Chart.show

        77



    //(x: float list, y: int list)
    member this.simpleBoxPlot(?x: 'dataType list, ?y: 'dataType list) : int =
        let x = defaultArg x []
        let y = defaultArg y []

        let plot =
            [ Chart.BoxPlot(
                  X = x,
                  Y = y,
                  BoxPoints = StyleParam.BoxPoints.All,
                  //QuartileMethod = StyleParam.QuartileMethod.Linear,
                  Jitter = 0.1,
                  Name = "Linear Quartile"
              )

              Chart.BoxPlot(
                  X = x,
                  Y = y,
                  BoxPoints = StyleParam.BoxPoints.All,
                  //QuartileMethod = StyleParam.QuartileMethod.Inclusive,
                  Jitter = 0.1,
                  Name = "Inclusive Quartile"
              )

              Chart.BoxPlot(
                  X = x,
                  Y = y,
                  BoxPoints = StyleParam.BoxPoints.All,
                  //QuartileMethod = StyleParam.QuartileMethod.Exclusive,
                  Jitter = 0.1,
                  Name = "Exclusive Quartile"
              ) ]
            |> Chart.combine
            |> Chart.show

        66



    member this.simpleHeatmap(xs: seq<float>, ys: seq<float>) : int =
        //
        let customColorscale = StyleParam.Colorscale.Bluered

        let colorBar =
            ColorBar.init (
                Title = Title.init ("Surface Heat", Side = StyleParam.Side.Top),
                TickLabelPosition = StyleParam.TickLabelPosition.Outside,
                TickMode = StyleParam.TickMode.Array,
                //TickVals = [| 2; 50; 100 |],
                TickText = [| "Cool"; "Mild"; "Hot" |]
            )

        let plot =
            Chart.Histogram2D(
                x = xs,
                y = ys,
                XBins = Bins.init (Start = 440., End = 570., Size = 5.),
                YBins = Bins.init (Start = 440., End = 570., Size = 5.),
                HistNorm = StyleParam.HistNorm.Probability,
                ColorScale = customColorscale
            )
            |> Chart.withColorBar (colorBar)
            |> Chart.show

        100




type Coords<'x, 'y, 'z, 't> = { x: 'x; y: 'y; z: 'x; t: 'y }

type ValueType =
    | Float of Coords<float, float, float, DateTime>
    | Int of Coords<int, int, int, DateTime>

//member this.nextBoxPlot : int =
//    let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
//    //let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
//    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
//    let box3 =
//        [
//            Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
//            Chart.BoxPlot("y'",y',Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
//        ]
//        |> Chart.combine
//    |> Chart.show
