using Aplicacao.Contratos.Repositorios;

namespace Aplicacao.Comandos.ConcluirTarefa
{
    public sealed class ConcluirTarefaCommandHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ConcluirTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<(bool Sucesso, string? Erro)> HandleAsync(
            ConcluirTarefaCommand command,
            CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(
                command.Id,
                cancellationToken);

            if (tarefa is null)
                return (false, "Tarefa não encontrada.");

            try
            {
                tarefa.Concluir();

                await _tarefaRepository.SalvarAlteracoesAsync(cancellationToken);

                return (true, null);
            }
            catch (InvalidOperationException exception)
            {
                return (false, exception.Message);
            }
        }
    }
}