namespace Survey.Core.Requests.Levantamentos
{
    /// <summary>
    /// Request para buscar todos os levantamentos.
    /// </summary>
    public class GetAllLevantamentosRequest : PagedRequest
    {
        /// <summary>
        /// Indentificação do funcionario.
        /// </summary>
        public Guid FuncionarioId { get; set; }
    }
}
