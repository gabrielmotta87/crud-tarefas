using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Tarefas.Configurations;

public static class EntityFrameworkConfig
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContextPool<ListaTarefaDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });

        return services;
    }
}