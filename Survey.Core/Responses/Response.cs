using System.Text.Json.Serialization;

namespace Survey.Core.Responses
{
    /// <summary>
    /// Classe de resposta.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class Response<TData>
    {
        /// <summary>
        /// Status code da resposta.
        /// </summary>
        private int _code = Configuration.DefaultStatusCode;

        /// <summary>
        /// Construtor padrão da resposta.
        /// </summary>
        [JsonConstructor]
        public Response()
            => _code = Configuration.DefaultStatusCode;

        /// <summary>
        /// Construtor da resposta.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public Response(
            TData? data,
            int code = Configuration.DefaultStatusCode,
            string? message = null)
        {
            Data = data;
            _code = code;
            Message = message;
        }

        /// <summary>
        /// Dados da resposta.
        /// </summary>
        public TData? Data { get; set; }

        /// <summary>
        /// messagem de resposta.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Controla se a resposata foi sucesso.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 and <= 299;
    }
}
