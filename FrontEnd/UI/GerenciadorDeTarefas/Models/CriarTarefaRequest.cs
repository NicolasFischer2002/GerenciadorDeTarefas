namespace GerenciadorDeTarefas.Models
{
    public sealed record CriarTarefaRequest
    {
        public string Titulo { get; }
        public string? Descricao { get; }

        public CriarTarefaRequest(string titulo, string? descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}