using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

internal class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefa", "dbo");

        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .UseIdentityColumn();

        builder
            .Property(t => t.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder
            .Property(t => t.Status)
            .HasColumnName("Status")
            .HasConversion<string>()
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder
            .Property(t => t.DataCriacao)
            .HasColumnName("DataCriacao")
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(t => t.DataAtualizacao)
            .HasColumnName("DataAtualizacao")
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.HasOne(t => t.ListaTarefa);
    }
}