using CRUD_Tarefas.Middlewares;

namespace CRUD_Tarefas.Configurations;

public static class MiddlewareConfig
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ExceptionValidatorMiddleware>();
}