namespace Survey.Core.Requests.Luminarias
{
    /// <summary>
    /// Requisição de buscar todas luminaria.
    /// </summary>
    public class GetAllLuminariasRequest : PagedRequest
    {
        /// <summary>
        /// Identificação do funcionario.
        /// </summary>
        public Guid FuncionarioId { get; set; }
    }
}
