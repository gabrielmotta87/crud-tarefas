using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Context;

public class ListaTarefaDbContext : DbContext
{
    public ListaTarefaDbContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}