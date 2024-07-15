using Survey.Core.Models;
using Survey.Core.Requests.Pavimentos;
using Survey.Core.Responses;

namespace Survey.Core.Handlers
{
    /// <summary>
    /// Interface do pavimento.
    /// </summary>
    public interface IPavimentoHandler
    {
        /// <summary>
        /// Metodo para criar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Pavimento?>> CreateAsync(CreatePavimentoRequest request);

        /// <summary>
        /// metodo para atualizar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Pavimento?>> UpdateAsync(UpdatePavimentoRequest request);

        /// <summary>
        /// Metodo para deletar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Pavimento?>> DeleteAsync(DeletePavimentoRequest request);

        /// <summary>
        /// Metodo para buscar um pavimento por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Pavimento?>> GetByIdAsync(GetPavimentoByIdRequest request);

        /// <summary>
        /// Metodo para buscar todos os pavimentos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResponse<List<Pavimento>?>> GetAllAsync(GetAllPavimentosRequest request);
    }
}
