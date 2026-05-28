using Aplicacao.Contratos.Repositorios;
using Dominio.Agregado;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Persistencia.Repositorios;

public sealed class TarefaRepository : ITarefaRepository
{
    private readonly TarefaDbContext _context;

    public TarefaRepository(TarefaDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Tarefa tarefa, CancellationToken cancellationToken)
    {
        await _context.Tarefas.AddAsync(
            tarefa,
            cancellationToken);
    }

    public async Task SalvarAlteracoesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Tarefa?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Tarefas
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<List<Tarefa>> ObterTodasAsync(CancellationToken cancellationToken)
    {
        return await _context.Tarefas.ToListAsync(cancellationToken);
    }

    public void Atualizar(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
    }

    public void Remover(Tarefa tarefa)
    {
        _context.Tarefas.Remove(tarefa);
    }
}