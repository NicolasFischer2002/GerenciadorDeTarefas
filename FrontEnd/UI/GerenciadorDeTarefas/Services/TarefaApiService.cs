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

        public async Task<List<TarefaViewModel>> ObterTodasAsync()
        {
            var tarefas =
                await _httpClient.GetFromJsonAsync<List<TarefaViewModel>>(
                    "tarefas");

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
    }
}