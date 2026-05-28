using Aplicacao.Contratos.Repositorios;
using Dominio.ValueObjects;

namespace Aplicacao.Comandos.AtualizarTarefa
{
    public sealed class AtualizarTarefaCommandHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public AtualizarTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<(bool Sucesso, string? Erro)> HandleAsync(
            AtualizarTarefaCommand command,
            CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(
                command.Id,
                cancellationToken);

            if (tarefa is null)
                return (false, "Tarefa não encontrada.");

            try
            {
                if (command.Titulo is not null)
                {
                    var titulo = new TituloTarefa(command.Titulo);

                    tarefa.AlterarTitulo(titulo);
                }

                if (command.Descricao is not null)
                {
                    var descricao = new DescricaoTarefa(command.Descricao);

                    tarefa.AlterarDescricao(descricao);
                }

                await _tarefaRepository.SalvarAlteracoesAsync(cancellationToken);

                return (true, null);
            }
            catch (Exception exception)
            {
                return (false, exception.Message);
            }
        }
    }
}