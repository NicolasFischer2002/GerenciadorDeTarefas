using Dominio.Constants;

namespace Aplicacao.Consultas.ObterTodas
{
    public sealed record ListarTarefasQuery
    {
        public StatusTarefa? Status { get; set; }
    }
}