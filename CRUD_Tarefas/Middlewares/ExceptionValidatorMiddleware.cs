
using Domain.Exceptions.Helpers;
using Domain.Models.Errors;
using System.Text.Json;

namespace CRUD_Tarefas.Middlewares;

public class ExceptionValidatorMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await CreateExceptionResponse(context, ex);
        }
    }

    private static Task CreateExceptionResponse(HttpContext context, Exception ex)
    {
        var statusCodeResult = ExceptionSelector.SelectStatusCode(ex);

        var errorResponse = JsonSerializer.Serialize(new ResponseError(statusCodeResult, ex.Message));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCodeResult;

        return context.Response.WriteAsync(errorResponse);
    }
}