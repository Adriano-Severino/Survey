namespace Survey.Core.Requests.Levantamentos
{
    /// <summary>
    /// Resquet de deletar o levantamento.
    /// </summary>
    public class DeleteLevantamentoRequest : Request
    {
        /// <summary>
        /// Indentificação do levantamento.
        /// </summary>
        public long Id { get; set; }
    }
}
