using System.Windows;

namespace GerenciadorDeTarefas.Mensagens
{
    public static class MessageBoxService
    {
        public static void ExibirErro(string mensagem)
        {
            MessageBox.Show(
                mensagem,
                "Erro",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void ExibirSucesso(string mensagem)
        {
            MessageBox.Show(
                mensagem,
                "Sucesso",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public static void ExibirAviso(string mensagem)
        {
            MessageBox.Show(
                mensagem,
                "Aviso",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }
}