namespace NewsApplication.API.Constants
{
    public enum Errorcodes
    {
        ApiKeyExhausted,
        ApiKeyMissing,
        ApiKeyInvalid,
        ApiKeyDisabled,
        ParametersMissing,
        ParametersIncompatible,
        ParameterInvalid,
        RateLimited,
        RequestTimeout,
        SourcesTooMany,
        SourceDoesNotExist,
        SourceUnavailableSortedBy,
        SourceTemporarilyUnavailable,
        UnexpectedError,
        UnknownError
    }
}
