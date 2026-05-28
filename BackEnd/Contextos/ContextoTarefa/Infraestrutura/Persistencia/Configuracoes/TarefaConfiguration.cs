using Dominio.Agregado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Persistencia.Configuracoes;

public sealed class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.OwnsOne(x => x.Titulo, titulo =>
        {
            titulo.Property(x => x.Valor)
                .HasColumnName("Titulo")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Descricao, descricao =>
        {
            descricao.Property(x => x.Valor)
                .HasColumnName("Descricao");
        });

        builder.Property(x => x.DataDeCriacao)
            .IsRequired();

        builder.Property(x => x.DataDeConclusao);

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .IsRequired();
    }
}