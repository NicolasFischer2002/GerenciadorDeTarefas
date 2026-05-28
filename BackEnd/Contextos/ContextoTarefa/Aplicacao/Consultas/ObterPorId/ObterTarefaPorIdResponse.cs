namespace Aplicacao.Consultas.ObterPorId
{
    public sealed record ObterTarefaPorIdResponse(
        int Id,
        string Titulo,
        string Descricao,
        DateTime DataDeCriacao,
        DateTime? DataDeConclusao,
        string Status);
}