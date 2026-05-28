using Dominio.Constants;
using Dominio.ValueObjects;

namespace Dominio.Agregado
{
    public sealed class Tarefa
    {
        public int Id { get; private set; }
        public TituloTarefa Titulo { get; private set; }
        public DescricaoTarefa Descricao { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime? DataDeConclusao { get; private set; }
        public StatusTarefa Status { get; private set; }

        private Tarefa() { }

        private Tarefa(
            TituloTarefa titulo,
            DescricaoTarefa descricao,
            DateTime dataDeCriacao,
            StatusTarefa status)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataDeCriacao = dataDeCriacao;
            Status = status;
        }

        public static Tarefa Criar(
            TituloTarefa titulo,
            DescricaoTarefa descricao)
        {
            if (titulo is null)
                throw new ArgumentNullException(
                    nameof(titulo),
                    "O título da tarefa é obrigatório.");

            descricao ??= new DescricaoTarefa(string.Empty);

            return new Tarefa(
                titulo,
                descricao,
                DateTime.UtcNow,
                StatusTarefa.Pendente);
        }

        public void Iniciar()
        {
            if (Status != StatusTarefa.Pendente)
                throw new InvalidOperationException(
                    "Somente tarefas pendentes podem ser iniciadas.");

            Status = StatusTarefa.EmProgresso;
        }

        public void Concluir()
        {
            if (Status != StatusTarefa.EmProgresso)
                throw new InvalidOperationException(
                    "Somente tarefas em progresso podem ser concluídas.");

            Status = StatusTarefa.Concluida;
            DataDeConclusao = DateTime.UtcNow;
        }

        public void Reabrir()
        {
            if (Status != StatusTarefa.Concluida)
                throw new InvalidOperationException(
                    "Somente tarefas concluídas podem ser reabertas.");

            Status = StatusTarefa.Pendente;
            DataDeConclusao = null;
        }

        public void AlterarTitulo(TituloTarefa titulo)
        {
            if (titulo is null)
                throw new ArgumentNullException(
                    nameof(titulo), 
                    "O título da tarefa é obrigatório.");

            Titulo = titulo;
        }

        public void AlterarDescricao(DescricaoTarefa descricao)
        {
            Descricao = descricao ?? new DescricaoTarefa(string.Empty);
        }
    }
}