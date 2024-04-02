namespace Domain.Models.Errors;

public class ResponseError
{
    public ResponseError(int statusCode, string? errorMessage)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }

    public int StatusCode { get; init; }
    public string? ErrorMessage { get; init; }
}