using Aplicacao.Contratos.Repositorios;

namespace Aplicacao.Comandos.IniciarTarefa
{
    public sealed class IniciarTarefaCommandHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public IniciarTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<(bool Sucesso, string? Erro)> HandleAsync(
            IniciarTarefaCommand command,
            CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(
                command.Id,
                cancellationToken);

            if (tarefa is null)
                return (false, "Tarefa não encontrada.");

            try
            {
                tarefa.Iniciar();

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