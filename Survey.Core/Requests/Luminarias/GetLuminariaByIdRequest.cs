namespace Survey.Core.Requests.Luminarias
{
    /// <summary>
    /// Requisição para buscar lumianria por id.
    /// </summary>
    public class GetLuminariaByIdRequest : Request
    {
        /// <summary>
        /// Identificação da luminaria.
        /// </summary>
        public long Id { get; set; }
    }
}
