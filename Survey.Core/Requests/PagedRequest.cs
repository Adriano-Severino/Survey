namespace Survey.Core.Requests
{
    /// <summary>
    /// Requisição de paginação.
    /// </summary>
    public class PagedRequest : Request
    {
        /// <summary>
        /// Tamanho da pagina.
        /// </summary>
        public int PageSize { get; set; } = Configuration.DefaultPageSize;

        /// <summary>
        /// Numeros de paginas.
        /// </summary>
        public int PageNumber { get; set; } = Configuration.DefaultPageNumber;

        /// <summary>
        /// Pular pagina.
        /// </summary>
        public int Skip { get; set; } = (Configuration.DefaultPageNumber - 1) * Configuration.DefaultPageSize;
    }
}
