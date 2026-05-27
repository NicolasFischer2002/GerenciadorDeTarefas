namespace Dominio.ValueObjects
{
    public sealed record TituloTarefa
    {
        public string Valor { get; }
        private const int ComprimentoMaximo = 100;

        public TituloTarefa(string? valor)
        {
            string valorFormatado = valor is null ? string.Empty : valor.Trim();

            if (string.IsNullOrWhiteSpace(valorFormatado))
                throw new ArgumentNullException(
                    nameof(valorFormatado), 
                    "O título da tarefa é obrigatório.");

            if (valorFormatado.Length > ComprimentoMaximo)
                throw new ArgumentOutOfRangeException(
                    nameof(valorFormatado), 
                    $"O título da tarefa não pode exceder {ComprimentoMaximo} caracteres.");

            Valor = valorFormatado;
        }

        public override string ToString() => Valor;
    }
}