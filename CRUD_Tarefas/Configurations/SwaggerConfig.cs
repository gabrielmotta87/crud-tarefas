using Microsoft.OpenApi.Models;

namespace CRUD_Tarefas.Configurations;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.EnableAnnotations();
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lista de Tarefas",
                Version = "v1"
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerConfig(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lista de Tarefas_v1"));

        return app;
    }
}