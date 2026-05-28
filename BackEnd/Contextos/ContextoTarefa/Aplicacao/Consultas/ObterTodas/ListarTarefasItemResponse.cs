namespace Aplicacao.Consultas.ObterTodas
{
    public sealed record ListarTarefasItemResponse(
        int Id,
        string Titulo,
        string Status,
        DateTime DataDeCriacao);
}