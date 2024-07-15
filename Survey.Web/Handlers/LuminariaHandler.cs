using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Luminarias;
using Survey.Core.Responses;
using System.Net.Http.Json;

namespace Survey.Web.Handlers
{
    /// <summary>
    /// Serviço da luminaria.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public class LuminariaHandler(IHttpClientFactory httpClientFactory) : ILuminariaHandler
    {
        /// <summary>
        /// Serviço de cliente da requisição.
        /// </summary>
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        /// <summary>
        /// Metodo para criar uma luminaria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> CreateAsync(CreateLuminariaRequest request)
        {
            var result = await _client.PostAsJsonAsync("api/v1/luminaria/create", request);
            return await result.Content.ReadFromJsonAsync<Response<Luminaria?>>()
                   ?? new Response<Luminaria?>(null, 400, "Falha ao criar a luminaria");
        }

        /// <summary>
        /// Metodo para atualizar uma luminaria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> UpdateAsync(UpdateLuminariaRequest request)
        {
            var result = await _client.PutAsJsonAsync($"api/v1/luminaria/update?id={request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Luminaria?>>()
                   ?? new Response<Luminaria?>(null, 400, "Falha ao criar o levantamento");
        }

        /// <summary>
        /// Metodo para deletar uma luminaria
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> DeleteAsync(DeleteLuminariaRequest request)
        {
            var result = await _client.DeleteAsync($"api/v1/luminaria/delete?id={request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Luminaria?>>()
                   ?? new Response<Luminaria?>(null, 400, "Falha ao excluir a luminaria");
        }

        /// <summary>
        /// Metodo para buscar uma luminaria por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> GetByIdAsync(GetLuminariaByIdRequest request)
            => await _client.GetFromJsonAsync<Response<Luminaria?>>($"api/v1/luminaria/get-by-id?id={request.Id}")
               ?? new Response<Luminaria?>(null, 400, "Não foi possível obter a luminaria");

        /// <summary>
        /// Metodo para buscar todas as luminarias.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Luminaria>?>> GetAllAsync(GetAllLuminariasRequest request)
            => await _client.GetFromJsonAsync<PagedResponse<List<Luminaria>?>>("api/v1/luminaria/get-all")
               ?? new PagedResponse<List<Luminaria>?>(null, 400, "Não foi possível obter as luminaria");
    }
}
