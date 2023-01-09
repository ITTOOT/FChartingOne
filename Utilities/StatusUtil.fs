module StatusUtil

//Status method
let returnCode (statusCode: int) : int =
    //Status of the operation
    if statusCode = 0 then 0
    elif statusCode = 1 then 1
    else 99
