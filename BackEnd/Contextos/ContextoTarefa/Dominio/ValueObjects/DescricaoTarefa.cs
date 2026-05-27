namespace Dominio.ValueObjects
{
    public sealed record DescricaoTarefa
    {
        public string Valor { get; }
        private const int ComprimentoMaximo = 250;

        public DescricaoTarefa(string? valor)
        {
            string valorFormatado = valor is null ? string.Empty : valor.Trim();

            if (valorFormatado.Length > ComprimentoMaximo)
                throw new ArgumentOutOfRangeException(
                    nameof(valorFormatado),
                    $"A descrição da tarefa não pode exceder {ComprimentoMaximo} caracteres.");

            Valor = valorFormatado;
        }
    }
}