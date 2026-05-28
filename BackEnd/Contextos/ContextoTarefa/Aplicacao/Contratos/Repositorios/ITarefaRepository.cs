using Dominio.Agregado;

namespace Aplicacao.Contratos.Repositorios;

public interface ITarefaRepository
{
    Task AdicionarAsync(
        Tarefa tarefa,
        CancellationToken cancellationToken);

    Task<Tarefa?> ObterPorIdAsync(
        int id,
        CancellationToken cancellationToken);

    Task<List<Tarefa>> ObterTodasAsync(
        CancellationToken cancellationToken);

    Task SalvarAlteracoesAsync(
        CancellationToken cancellationToken);

    void Atualizar(Tarefa tarefa);

    void Remover(Tarefa tarefa);
}