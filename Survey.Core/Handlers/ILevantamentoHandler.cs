using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;
using Survey.Core.Responses;

namespace Survey.Core.Handlers
{
    /// <summary>
    /// Interface do levantamento
    /// </summary>
    public interface ILevantamentoHandler
    {
        /// <summary>
        /// Metodo de criar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Levantamento?>> CreateAsync(CreateLevantamentoRequest request);

        /// <summary>
        /// Metodo de atualizar um lentamento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Levantamento?>> UpdateAsync(UpdateLevantamentoRequest request);

        /// <summary>
        /// Metodo de deletar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Levantamento?>> DeleteAsync(DeleteLevantamentoRequest request);

        /// <summary>
        /// Metodo de buscar um lentamento por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Levantamento?>> GetByIdAsync(GetLevantamentoByIdRequest request);

        /// <summary>
        /// Meotdo de buscar todos os levantamentos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResponse<List<Levantamento>?>> GetAllAsync(GetAllLevantamentosRequest request);
    }
}
