using GerenciadorDeTarefas.Mensagens;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Services;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

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
        public string StatusSelecionado { get; set; } = "Todos";

        public MainWindow()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5277")
            };

            _tarefaApiService = new TarefaApiService(httpClient);

            InitializeComponent();

            DataContext = this;

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
            string? status = StatusSelecionado == "Todos"
                ? null
                : StatusSelecionado;

            var tarefas = await _tarefaApiService.ObterTodasAsync(status);

            Tarefas.Clear();

            foreach (var tarefa in tarefas)
            {
                Tarefas.Add(tarefa);
            }
        }

        private async void StatusFiltroComboBox_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (StatusFiltroComboBox.SelectedItem is not ComboBoxItem item)
                return;

            StatusSelecionado = item.Content.ToString() ?? "Todos";

            await CarregarTarefasAsync();
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

        private async void ExcluirButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is not Button button || button.DataContext is not TarefaViewModel tarefa)
                    return;

                await _tarefaApiService.ExcluirAsync(tarefa.Id);
                MessageBoxService.ExibirSucesso("Tarefa excluída com sucesso.");
                await CarregarTarefasAsync();
            }
            catch (Exception exception)
            {
                MessageBoxService.ExibirErro(exception.Message);
            }
        }

        private async void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;

            if (button.DataContext is not TarefaViewModel tarefa)
                return;

            var janelaEdicao = new EditarTarefaWindow(tarefa.Id)
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            janelaEdicao.ShowDialog();

            await CarregarTarefasAsync();
        }
    }
}