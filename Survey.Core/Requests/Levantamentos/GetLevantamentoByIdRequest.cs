namespace Survey.Core.Requests.Levantamentos
{
    /// <summary>
    /// Reqeust para buscar um levantamento por id.
    /// </summary>
    public class GetLevantamentoByIdRequest : Request
    {
        /// <summary>
        /// Identificação do id.
        /// </summary>
        public long Id { get; set; }
    }
}
