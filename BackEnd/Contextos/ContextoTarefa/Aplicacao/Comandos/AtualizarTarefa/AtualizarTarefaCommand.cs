namespace Aplicacao.Comandos.AtualizarTarefa
{
    public sealed record AtualizarTarefaCommand(
        int Id,
        string? Titulo,
        string? Descricao);
}