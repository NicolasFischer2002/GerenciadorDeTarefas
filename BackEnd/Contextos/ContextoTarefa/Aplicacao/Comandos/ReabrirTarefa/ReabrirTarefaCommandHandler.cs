using Aplicacao.Contratos.Repositorios;

namespace Aplicacao.Comandos.ReabrirTarefa
{
    public sealed class ReabrirTarefaCommandHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ReabrirTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<(bool Sucesso, string? Erro)> HandleAsync(
            ReabrirTarefaCommand command,
            CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(
                command.Id,
                cancellationToken);

            if (tarefa is null)
                return (false, "Tarefa não encontrada.");

            try
            {
                tarefa.Reabrir();

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