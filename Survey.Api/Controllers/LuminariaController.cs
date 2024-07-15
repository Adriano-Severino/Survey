using Microsoft.AspNetCore.Mvc;
using Survey.Core;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Luminarias;
using Survey.Core.Responses;

namespace Survey.Api.Controllers
{
    /// <summary>
    /// Controller responsavel pela requisição da luminaria.
    /// </summary>
    /// <param name="handler"></param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LuminariaController(ILuminariaHandler handler) : ControllerBase
    {
        /// <summary>
        /// Cria uma nova lumianria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(IResult), 201)]
        [ProducesResponseType(typeof(IResult), 400)]
        public async Task<IResult> CreateAsync(CreateLuminariaRequest request)
        {
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/luminaria/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Buscar todas as luminarias.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Resposta pagina contendo uma lista de luminarias</returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(PagedResponse<List<Luminaria>>), 200)]
        public async Task<IResult> GetAllAsync(
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllLuminariasRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;

            var response = await handler.GetAllAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);

        }

        /// <summary>
        /// Buscar a luminaria por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Resposta contendo uma luminaria</returns>
        [HttpGet]
        [Route("get-by-id")]
        [ProducesResponseType(typeof(Response<Luminaria>), 200)]
        public async Task<IResult> GetByIdAsync(long id)
        {
            var request = new GetLuminariaByIdRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.GetByIdAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Atualiza uma luminaria por id.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(Response<Luminaria>), 200)]
        public async Task<IResult> UpdateAsync(UpdateLuminariaRequest request, long id)
        {
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Deleta uma luminaria por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(Response<Luminaria>), 200)]
        public async Task<IResult> DeleteAsync(long id)
        {
            var request = new DeleteLuminariaRequest();
            request.FuncionarioId = ApiConfiguration.FuncionarioId;
            request.Id = id;
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
