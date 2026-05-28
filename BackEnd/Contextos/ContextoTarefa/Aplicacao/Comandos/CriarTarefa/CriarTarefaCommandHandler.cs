using Aplicacao.Contratos.Repositorios;
using Dominio.Agregado;
using Dominio.ValueObjects;

namespace Aplicacao.Comandos.CriarTarefa;

public sealed class CriarTarefaCommandHandler
{
    private readonly ITarefaRepository _tarefaRepository;

    public CriarTarefaCommandHandler(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<CriarTarefaResponse> HandleAsync(
        CriarTarefaCommand command,
        CancellationToken cancellationToken)
    {
        var titulo = new TituloTarefa(command.Titulo);

        var descricao = new DescricaoTarefa(command.Descricao ?? string.Empty);

        var tarefa = Tarefa.Criar(titulo, descricao);

        await _tarefaRepository.AdicionarAsync(tarefa, cancellationToken);

        await _tarefaRepository.SalvarAlteracoesAsync(cancellationToken);

        return new CriarTarefaResponse(
            tarefa.Id,
            tarefa.Titulo.Valor,
            tarefa.Descricao.Valor,
            tarefa.DataDeCriacao,
            tarefa.Status.ToString());
    }
}