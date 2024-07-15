namespace Survey.Core.Requests.Pavimentos
{
    /// <summary>
    /// Requisição para buscar todos os pavimento.
    /// </summary>
    public class GetAllPavimentosRequest : PagedRequest
    {
        /// <summary>
        /// Identificação do funcionario.
        /// </summary>
        public Guid FuncionarioId { get; set; }
    }
}
