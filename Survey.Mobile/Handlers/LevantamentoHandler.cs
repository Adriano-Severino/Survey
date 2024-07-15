using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;
using Survey.Core.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Survey.Mobile.Handlers
{
    /// <summary>
    /// Serviço do levantamento.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public class LevantamentoHandler(IHttpClientFactory httpClientFactory) : ILevantamentoHandler
    {
        /// <summary>
        /// Serviço de cliente da requisição.
        /// </summary>
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        /// <summary>
        /// Metodo para criar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> CreateAsync(CreateLevantamentoRequest request)
        {
            var result = await _client.PostAsJsonAsync("api/v1/levantamento/create", request);
            return await result.Content.ReadFromJsonAsync<Response<Levantamento?>>()
                   ?? new Response<Levantamento?>(null, 400, "Falha ao criar o levantamento");
        }

        /// <summary>
        /// Metodo para atualizar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> UpdateAsync(UpdateLevantamentoRequest request)
        {
            var result = await _client.PutAsJsonAsync($"api/v1/levantamento/update?id={request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Levantamento?>>()
                   ?? new Response<Levantamento?>(null, 400, "Falha ao atualizar o levantamento");
        }

        /// <summary>
        /// Metodo para deletar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> DeleteAsync(DeleteLevantamentoRequest request)
        {
            var result = await _client.DeleteAsync($"api/v1/levantamento/delete?id={request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Levantamento?>>()
                   ?? new Response<Levantamento?>(null, 400, "Falha ao excluir o levantamento");
        }

        /// <summary>
        /// Metodo para buscar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> GetByIdAsync(GetLevantamentoByIdRequest request)
            => await _client.GetFromJsonAsync<Response<Levantamento?>>($"api/v1/levantamento/get-by-id?id={request.Id}")
               ?? new Response<Levantamento?>(null, 400, "Não foi possível obter o levantamento");

        /// <summary>
        /// Metodo para buscar todos os levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Levantamento>?>> GetAllAsync(GetAllLevantamentosRequest request)
            => await _client.GetFromJsonAsync<PagedResponse<List<Levantamento>?>>("api/v1/levantamento/get-all")
               ?? new PagedResponse<List<Levantamento>?>(null, 400, "Não foi possível obter os levantamento");
    }
}
