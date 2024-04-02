using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CRUD_Tarefas.Configurations;
public static class HealthcheckConfig
{
    public static IServiceCollection AddHealthChecksConfig(this IServiceCollection services, IConfiguration config)
    {
        services.AddHealthChecksUI().AddInMemoryStorage();

        services.AddHealthChecks()
            .AddCheck(name: "API Lista de Tarefas", () => HealthCheckResult.Healthy("API Lista de Tarefas"))
            .AddSqlServer(connectionString: config.GetConnectionString("SqlServer")!, name: "Banco de Dados SQL Server");

        return services;
    }

    public static IApplicationBuilder UseHealthChecksConfig(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/hc", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(opt => { opt.UIPath = "/healthchecks-ui"; });

        return app;
    }
}