using Aplicacao.Contratos.Repositorios;

namespace Aplicacao.Consultas.ObterPorId
{
    public sealed class ObterTarefaPorIdQueryHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ObterTarefaPorIdQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<ObterTarefaPorIdResponse?> HandleAsync(
            ObterTarefaPorIdQuery query,
            CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorIdSomenteLeituraAsync(
                query.Id,
                cancellationToken);

            if (tarefa is null)
                return null;

            return new ObterTarefaPorIdResponse(
                tarefa.Id,
                tarefa.Titulo.Valor,
                tarefa.Descricao.Valor,
                tarefa.DataDeCriacao,
                tarefa.DataDeConclusao,
                tarefa.Status.ToString());
        }
    }
}