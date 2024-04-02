using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

internal class ListaTarefaConfiguration : IEntityTypeConfiguration<ListaTarefa>
{
    public void Configure(EntityTypeBuilder<ListaTarefa> builder)
    {
        builder.ToTable("ListaTarefa", "dbo");

        builder.HasKey(lt => lt.Id);

        builder
            .Property(lt => lt.Id)
            .UseIdentityColumn();

        builder
            .Property(lt => lt.Responsavel)
            .HasColumnName("Responsavel")
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder
            .HasMany(lt => lt.Tarefas)
            .WithOne(t => t.ListaTarefa)
            .IsRequired(false);

        builder
            .HasIndex(lt => lt.Responsavel)
            .IsUnique()
            .HasDatabaseName("UQ_Responsavel");
    }
}