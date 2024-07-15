using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Pavimentos;
using Survey.Core.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Survey.Mobile.Handlers
{
    /// <summary>
    /// Serviço do pavimento.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public class PavimentoHandler(IHttpClientFactory httpClientFactory) : IPavimentoHandler
    {
        /// <summary>
        /// /// Serviço de cliente da requisição.
        /// </summary>
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        /// <summary>
        /// Metodo para criar um pavimento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> CreateAsync(CreatePavimentoRequest request)
        {
            var result = await _client.PostAsJsonAsync("api/v1/pavimento/create", request);
            return await result.Content.ReadFromJsonAsync<Response<Pavimento?>>()
                   ?? new Response<Pavimento?>(null, 400, "Falha ao criar o pavimento");
        }

        /// <summary>
        /// Metodo para atualizar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> UpdateAsync(UpdatePavimentoRequest request)
        {
            var result = await _client.PutAsJsonAsync($"api/v1/pavimento/update?id={request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Pavimento?>>()
                   ?? new Response<Pavimento?>(null, 400, "Falha ao atualizar o pavimento");
        }

        /// <summary>
        /// Metodo para deletar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> DeleteAsync(DeletePavimentoRequest request)
        {
            var result = await _client.DeleteAsync($"api/v1/pavimento/delete?id={request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Pavimento?>>()
                   ?? new Response<Pavimento?>(null, 400, "Falha ao excluir o pavimento");
        }

        /// <summary>
        /// Metodo para buscar um pavimento por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> GetByIdAsync(GetPavimentoByIdRequest request)
            => await _client.GetFromJsonAsync<Response<Pavimento?>>($"api/v1/pavimento/get-by-id?id={request.Id}")
               ?? new Response<Pavimento?>(null, 400, "Não foi possível obter o pavimento");

        /// <summary>
        /// Metodo para buscar todos os pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Pavimento>?>> GetAllAsync(GetAllPavimentosRequest request)
            => await _client.GetFromJsonAsync<PagedResponse<List<Pavimento>?>>("api/v1/pavimento/get-all")
               ?? new PagedResponse<List<Pavimento>?>(null, 400, "Não foi possível obter os pavimentos");
    }
}
