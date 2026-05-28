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

    public async Task<Tarefa?> ObterPorIdSomenteLeituraAsync(
        int id, 
        CancellationToken cancellationToken)
    {
        return await _context.Tarefas
            .AsNoTracking()
            .FirstOrDefaultAsync(
                tarefa => tarefa.Id == id,
                cancellationToken);
    }

    /// <summary>
    /// Obtém uma tarefa por ID para leitura e escrita. 
    /// Use este método apenas se for necessário modificar a entidade, caso contrário, 
    /// prefira o método de somente leitura para melhor desempenho.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Tarefa?> ObterPorIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await _context.Tarefas
            .FirstOrDefaultAsync(
                tarefa => tarefa.Id == id,
                cancellationToken);
    }

    public async Task<IReadOnlyCollection<Tarefa>> ObterTodasAsync(
        CancellationToken cancellationToken)
    {
        return await _context.Tarefas
            .AsNoTracking()
            .OrderByDescending(tarefa => tarefa.DataDeCriacao)
            .ToListAsync(cancellationToken);
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