module UseCaseResult

type UseCaseResult<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure