using System.Text.Json.Serialization;

namespace Survey.Core.Responses
{
    /// <summary>
    /// Resposta da solicitação
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class PagedResponse<TData> : Response<TData>
    {
        /// <summary>
        /// Construtor padrão da resposta.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="totalCount"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        [JsonConstructor]
        public PagedResponse(
            TData? data,
            int totalCount,
            int currentPage = 1,
            int pageSize = Configuration.DefaultPageSize)
            : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        /// <summary>
        /// Construtor da resposta.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public PagedResponse(
            TData? data,
            int code = Configuration.DefaultStatusCode,
            string? message = null)
            : base(data, code, message)
        {
        }

        /// <summary>
        /// Pagina atual.
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Total de paginas.
        /// </summary>
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        /// <summary>
        /// Tamanho da pagina.
        /// </summary>
        public int PageSize { get; set; } = Configuration.DefaultPageSize;

        /// <summary>
        /// Total de registros.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
