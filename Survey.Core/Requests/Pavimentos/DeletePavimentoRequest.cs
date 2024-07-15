namespace Survey.Core.Requests.Pavimentos
{
    /// <summary>
    /// Requisição de deletar o pavimento por id.
    /// </summary>
    public class DeletePavimentoRequest : Request
    {
        /// <summary>
        /// Indetificação do pavimento.
        /// </summary>
        public long Id { get; set; }
    }
}
