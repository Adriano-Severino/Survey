using Microsoft.AspNetCore.Mvc;
using Survey.Core;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;
using Survey.Core.Responses;

namespace Survey.Api.Controllers
{
    /// <summary>
    /// Controller responsavel pela requisição de levantamento.
    /// </summary>
    /// <param name="handler"></param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LevantamentoController(ILevantamentoHandler handler) : ControllerBase
    {
        /// <summary>
        /// Cria um novo levantamento.
        /// </summary>
        /// <param name="request">Dados do levantamento a ser criado.</param>
        /// <returns>Resposta da criação do levantamento.</returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(IResult), 201)]
        [ProducesResponseType(typeof(IResult), 400)]
        public async Task<IResult> CreateAsync(CreateLevantamentoRequest request)
        {
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/levantamento/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Busca todos os levantamentos.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Resposta da busca de todos os levantamentos</returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(PagedResponse<List<Levantamento>>), 200)]
        public async Task<IResult> GetAllAsync(
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllLevantamentosRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;

            var response = await handler.GetAllAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);

        }

        /// <summary>
        /// Buscar o levantamento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Resposta da busca do levantamento por id</returns>
        [HttpGet]
        [Route("get-by-id")]
        [ProducesResponseType(typeof(Response<Levantamento>), 200)]
        public async Task<IResult> GetByIdAsync(long id)
        {
            var request = new GetLevantamentoByIdRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.GetByIdAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Atualiza um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>Resposta da atualização do levantamento</returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(Response<Levantamento>), 200)]
        public async Task<IResult> UpdateAsync(UpdateLevantamentoRequest request, long id)
        {
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Deleta o levantamento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Resposta da exclusão do levantamento</returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(Response<Levantamento>), 200)]
        public async Task<IResult> DeleteAsync(long id)
        {
            var request = new DeleteLevantamentoRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
