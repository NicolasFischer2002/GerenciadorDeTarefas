namespace Aplicacao.Comandos.CriarTarefa
{
    public sealed record CriarTarefaResponse(
        int Id,
        string Titulo,
        string? Descricao,
        DateTime DataDeCriacao,
        string Status);
}