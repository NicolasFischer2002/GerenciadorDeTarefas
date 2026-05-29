using GerenciadorDeTarefas.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace GerenciadorDeTarefas.Services
{
    public sealed class TarefaApiService
    {
        private readonly HttpClient _httpClient;

        public TarefaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TarefaViewModel>> ObterTodasAsync(string? status = null)
        {
            var url = "tarefas";

            if (!string.IsNullOrWhiteSpace(status))
            {
                url += $"?status={status}";
            }

            var tarefas =
                await _httpClient.GetFromJsonAsync<List<TarefaViewModel>>(url);

            return tarefas ?? [];
        }

        public async Task CriarAsync(CriarTarefaRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "/tarefas",
                request);

            if (response.IsSuccessStatusCode)
                return;

            var mensagem = ObterMensagemErroApi(await response.Content.ReadAsStringAsync());

            throw new Exception(mensagem);
        }

        private static string ObterMensagemErroApi(string? conteudo)
        {
            if (conteudo == null)
                return "Erro desconhecido";

            var json = JsonDocument.Parse(conteudo);

            var mensagem =
                json.RootElement.TryGetProperty("error", out var errorProp)
                    ? errorProp.GetString()
                    : "Erro desconhecido";

            return mensagem ?? "Erro desconhecido";
        }

        public async Task ExcluirAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/tarefas/{id}");

            if (response.IsSuccessStatusCode)
                return;

            var mensagem = ObterMensagemErroApi(await response.Content.ReadAsStringAsync());
            throw new Exception(mensagem);
        }

        public async Task<TarefaViewModel> ObterPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/tarefas/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var mensagem = await response.Content.ReadAsStringAsync();
                throw new Exception(mensagem);
            }

            var json = await response.Content.ReadAsStringAsync();

            var tarefa = JsonSerializer.Deserialize<TarefaViewModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (tarefa is null)
                throw new Exception("Não foi possível carregar a tarefa.");

            return tarefa;
        }

        public async Task AtualizarAsync(AtualizarTarefaRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"/tarefas/{request.Id}",
                request);

            if (response.IsSuccessStatusCode)
                return;

            var mensagem = ObterMensagemErroApi(await response.Content.ReadAsStringAsync());
            throw new Exception(mensagem);
        }

        public async Task IniciarAsync(int id)
        {
            var response = await _httpClient.PutAsync(
                $"/tarefas/{id}/iniciar",
                null);

            if (response.IsSuccessStatusCode)
                return;

            var mensagem = await response.Content.ReadAsStringAsync();
            throw new Exception(mensagem);
        }

        public async Task ConcluirAsync(int id)
        {
            var response = await _httpClient.PutAsync(
                $"/tarefas/{id}/concluir",
                null);

            if (response.IsSuccessStatusCode)
                return;

            var mensagem = await response.Content.ReadAsStringAsync();
            throw new Exception(mensagem);
        }

        public async Task ReabrirAsync(int id)
        {
            var response = await _httpClient.PutAsync(
                $"/tarefas/{id}/reabrir",
                null);

            if (response.IsSuccessStatusCode)
                return;

            var mensagem = await response.Content.ReadAsStringAsync();
            throw new Exception(mensagem);
        }
    }
}