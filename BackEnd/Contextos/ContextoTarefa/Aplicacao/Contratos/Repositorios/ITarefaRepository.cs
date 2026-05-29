using Dominio.Agregado;
using Dominio.Constants;

namespace Aplicacao.Contratos.Repositorios;

public interface ITarefaRepository
{
    Task AdicionarAsync(
        Tarefa tarefa,
        CancellationToken cancellationToken);

    Task<Tarefa?> ObterPorIdSomenteLeituraAsync(
        int id,
        CancellationToken cancellationToken);

    Task<Tarefa?> ObterPorIdAsync(
        int id,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Tarefa>> ObterTodasAsync(
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Tarefa>> ObterTodasPorStatusAsync(
        StatusTarefa status,
        CancellationToken cancellationToken);

    Task SalvarAlteracoesAsync(
        CancellationToken cancellationToken);

    void Atualizar(Tarefa tarefa);

    void Remover(Tarefa tarefa);
}