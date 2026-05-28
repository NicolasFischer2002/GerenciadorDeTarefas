using Dominio.Agregado;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Persistencia;

public sealed class TarefaDbContext : DbContext
{
    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    public TarefaDbContext(DbContextOptions<TarefaDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TarefaDbContext).Assembly);
    }
}