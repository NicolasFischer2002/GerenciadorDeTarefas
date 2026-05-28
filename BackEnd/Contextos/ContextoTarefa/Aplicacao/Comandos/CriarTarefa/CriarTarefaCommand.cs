namespace Aplicacao.Comandos.CriarTarefa
{
    public sealed record CriarTarefaCommand(
        string Titulo,
        string? Descricao);
}