namespace GerenciadorDeTarefas.Models
{
    public sealed class CriarTarefaRequest
    {
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }

        public CriarTarefaRequest(string titulo, string? descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}