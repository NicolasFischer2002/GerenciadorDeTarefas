using Aplicacao.Contratos.Repositorios;

namespace Aplicacao.Consultas.ObterTodas
{
    public sealed class ListarTarefasQueryHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ListarTarefasQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IReadOnlyCollection<ListarTarefasItemResponse>> HandleAsync(
            ListarTarefasQuery query,
            CancellationToken cancellationToken)
        {
            var tarefas = await _tarefaRepository.ObterTodasAsync(cancellationToken);

            return [.. tarefas
                .Select(tarefa => new ListarTarefasItemResponse(
                    tarefa.Id,
                    tarefa.Titulo.Valor,
                    tarefa.Status.ToString(),
                    tarefa.DataDeCriacao))];
        }
    }
}