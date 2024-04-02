using System.Net;

namespace Domain.Exceptions.Helpers;

public static class ExceptionSelector
{
    public static int SelectStatusCode(Exception ex)
    {
        var exceptionType = ex.GetType().Name;

        var statusCode = exceptionType switch
        {
            nameof(ListaDeTarefaBadRequestException) => (int)HttpStatusCode.BadRequest,
            nameof(ListaDeTarefaNotFoundException) => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        return statusCode;
    }
}