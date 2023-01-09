module SoMCharts

open System

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open Plotly.NET.Interactive
//for heatmap
open FSharp.Stats.Distributions

//Plotter class for SOM charts
type Plotter
    (
        ?xNeuron: double list,
        ?yNeuron: double list,
        ?weightsNeuron: double list,
        ?neuronCount: int,
        ?xVector: double list,
        ?yVector: double list,
        ?vectorCount: int,
        ?id: double list,
        ?label: string list,
        ?timestamp: DateTime list,
        ?overallResult: int list,
        ?cycleTime: double list,
        ?capnutTypeResult: int list,
        ?omvSpringResult: int list,
        ?nozzlePreLoadForce: double list,
        ?nozzlePreLoadPosition: double list,
        ?stackBuildResult: int list,
        ?capnutTorque: double list,
        ?capnutTorqueAngle: double list,
        ?capnutFinalAngle: double list,
        ?capnutAssemblyResult: int list
    ) =

    //CONSTRUCTOR
    new() =
        Plotter(
            xNeuron = [],
            yNeuron = [],
            weightsNeuron = [],
            neuronCount = 0,
            xVector = [],
            yVector = [],
            vectorCount = 0,
            id = [],
            label = [],
            timestamp = [],
            overallResult = [],
            cycleTime = [],
            capnutTypeResult = [],
            omvSpringResult = [],
            nozzlePreLoadForce = [],
            nozzlePreLoadPosition = [],
            stackBuildResult = [],
            capnutTorque = [],
            capnutTorqueAngle = [],
            capnutFinalAngle = [],
            capnutAssemblyResult = []
        )

    //
    member this.simpleBarChart() : int =



        100
