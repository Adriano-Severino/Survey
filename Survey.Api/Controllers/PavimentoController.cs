using Microsoft.AspNetCore.Mvc;
using Survey.Core;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Pavimentos;
using Survey.Core.Responses;

namespace Survey.Api.Controllers
{
    /// <summary>
    /// Controller responsavel pela requisição do pavimento
    /// </summary>
    /// <param name="handler"></param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PavimentoController(IPavimentoHandler handler) : ControllerBase
    {
        /// <summary>
        /// Cria um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(IResult), 201)]
        [ProducesResponseType(typeof(IResult), 400)]
        public async Task<IResult> CreateAsync(CreatePavimentoRequest request)
        {
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/pavimento/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Busca todos os pavimentos.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Resposa pagina com uma lista de pavimentos</returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(PagedResponse<List<Pavimento>>), 200)]
        public async Task<IResult> GetAllAsync(
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllPavimentosRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;

            var response = await handler.GetAllAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);

        }

        /// <summary>
        /// Buscar um pavimento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-by-id")]
        [ProducesResponseType(typeof(Response<Pavimento>), 200)]
        public async Task<IResult> GetByIdAsync(long id)
        {
            var request = new GetPavimentoByIdRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.GetByIdAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Atualiza um pavimento por id.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(Response<Pavimento>), 200)]
        public async Task<IResult> UpdateAsync(UpdatePavimentoRequest request, long id)
        {
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Deleta um pavimento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(Response<Pavimento>), 200)]
        public async Task<IResult> DeleteAsync(long id)
        {
            var request = new DeletePavimentoRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
