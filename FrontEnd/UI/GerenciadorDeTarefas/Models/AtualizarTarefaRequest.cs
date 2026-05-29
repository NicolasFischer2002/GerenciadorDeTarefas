namespace GerenciadorDeTarefas.Models
{
    public sealed record AtualizarTarefaRequest
    {
        public int Id { get; }
        public string Titulo { get; }
        public string Descricao { get; }

        public AtualizarTarefaRequest(int id, string titulo, string descricao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}