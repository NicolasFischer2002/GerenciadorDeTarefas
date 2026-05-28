using Aplicacao.Contratos.Repositorios;

namespace Aplicacao.Comandos.ExcluirTarefa
{
    public sealed class ExcluirTarefaCommandHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ExcluirTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<bool> HandleAsync(
            ExcluirTarefaCommand command,
            CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(
                command.Id,
                cancellationToken);

            if (tarefa is null)
                return false;

            _tarefaRepository.Remover(tarefa);

            await _tarefaRepository.SalvarAlteracoesAsync(cancellationToken);

            return true;
        }
    }
}