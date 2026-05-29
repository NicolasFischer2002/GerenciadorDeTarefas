using Dominio.Constants;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Services;
using System.Net.Http;
using System.Windows;

namespace GerenciadorDeTarefas
{
    public partial class EditarTarefaWindow : Window
    {
        private readonly int _tarefaId;
        private readonly TarefaApiService _tarefaApiService;
        private StatusTarefa _statusAtual;

        public EditarTarefaWindow(int tarefaId)
        {
            InitializeComponent();

            _tarefaId = tarefaId;

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5277")
            };

            _tarefaApiService = new TarefaApiService(httpClient);

            Loaded += EditarTarefaWindow_Loaded;
        }

        private async void EditarTarefaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await CarregarTarefa();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private async Task CarregarTarefa()
        {
            var tarefa = await _tarefaApiService.ObterPorIdAsync(_tarefaId);

            TituloTextBox.Text = tarefa.Titulo;
            DescricaoTextBox.Text = tarefa.Descricao;

            _statusAtual = Enum.Parse<StatusTarefa>(tarefa.Status);

            ConfigurarBotaoStatus();
        }

        private void ConfigurarBotaoStatus()
        {
            switch (_statusAtual)
            {
                case StatusTarefa.Pendente:
                    StatusActionButton.Content = "Iniciar";
                    StatusActionButton.Visibility = Visibility.Visible;
                    break;

                case StatusTarefa.EmProgresso:
                    StatusActionButton.Content = "Finalizar";
                    StatusActionButton.Visibility = Visibility.Visible;
                    break;

                case StatusTarefa.Concluida:
                    StatusActionButton.Content = "Reabrir";
                    StatusActionButton.Visibility = Visibility.Visible;
                    break;
            }
        }

        private async void StatusActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (_statusAtual)
                {
                    case StatusTarefa.Pendente:
                        await _tarefaApiService.IniciarAsync(_tarefaId);
                        _statusAtual = StatusTarefa.EmProgresso;
                        break;

                    case StatusTarefa.EmProgresso:
                        await _tarefaApiService.ConcluirAsync(_tarefaId);
                        _statusAtual = StatusTarefa.Concluida;
                        break;

                    case StatusTarefa.Concluida:
                        await _tarefaApiService.ReabrirAsync(_tarefaId);
                        _statusAtual = StatusTarefa.Pendente;
                        break;
                }

                ConfigurarBotaoStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private async void Salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var comando = new AtualizarTarefaRequest(
                    _tarefaId, 
                    TituloTextBox.Text, 
                    DescricaoTextBox.Text);

                await _tarefaApiService.AtualizarAsync(comando);

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}