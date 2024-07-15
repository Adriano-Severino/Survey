using Survey.Core.Models;
using Survey.Core.Requests.Luminarias;
using Survey.Core.Responses;

namespace Survey.Core.Handlers
{
    /// <summary>
    /// Interface da luminaria.
    /// </summary>
    public interface ILuminariaHandler
    {
        /// <summary>
        /// Metodo de criar uma lumianria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Luminaria?>> CreateAsync(CreateLuminariaRequest request);

        /// <summary>
        /// Metodo de atualizar uma luminaria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Luminaria?>> UpdateAsync(UpdateLuminariaRequest request);

        /// <summary>
        /// Metoto de deletar uma luminaria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Luminaria?>> DeleteAsync(DeleteLuminariaRequest request);

        /// <summary>
        /// Metodo de buscar uma luminaria por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Luminaria?>> GetByIdAsync(GetLuminariaByIdRequest request);

        /// <summary>
        /// Metodo de buscar todas as luminarias.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResponse<List<Luminaria>?>> GetAllAsync(GetAllLuminariasRequest request);
    }
}
