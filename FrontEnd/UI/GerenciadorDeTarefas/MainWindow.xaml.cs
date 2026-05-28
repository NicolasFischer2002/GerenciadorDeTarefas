using GerenciadorDeTarefas.Mensagens;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Services;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;

namespace GerenciadorDeTarefas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TarefaApiService _tarefaApiService;

        public ObservableCollection<TarefaViewModel> Tarefas { get; set; } = [];
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5277")
            };

            _tarefaApiService =
                new TarefaApiService(httpClient);

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            await CarregarTarefasAsync();
        }

        private async Task CarregarTarefasAsync()
        {
            var tarefas =
                await _tarefaApiService.ObterTodasAsync();

            Tarefas.Clear();

            foreach (var tarefa in tarefas)
            {
                Tarefas.Add(tarefa);
            }
        }

        private async void AdicionarButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                var request = new CriarTarefaRequest(TituloTextBox.Text, DescricaoTextBox.Text);

                await _tarefaApiService.CriarAsync(request);

                MessageBoxService.ExibirSucesso("Tarefa criada com sucesso.");

                TituloTextBox.Text = string.Empty;
                DescricaoTextBox.Text = string.Empty;

                await CarregarTarefasAsync();
            }
            catch (Exception exception)
            {
                MessageBoxService.ExibirErro(exception.Message);
            }
        }
    }
}