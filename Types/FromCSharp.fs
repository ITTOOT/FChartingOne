module FromCSharp

//Matrix
type MatrixOutput<'x, 'y, 'w> =
    struct
        val X: 'x
        val Y: 'y
        val Weights: 'w

        new(x, y, w) = { X = x; Y = y; Weights = w }
    end

//Series
type SeriesOutput<'x, 'y, 'z, 'inputList, 'labelList, 'inputCount> =
    struct
        val X: 'x
        val Y: 'y
        val Z: 'z
        val InputList: 'inputList
        val LabelList: 'labelList
        val InputCount: 'inputCount

        new(x, y, z, inputList, labelList, inputCount) =
            { X = x
              Y = y
              Z = z
              InputList = inputList
              LabelList = labelList
              InputCount = inputCount }
    end
