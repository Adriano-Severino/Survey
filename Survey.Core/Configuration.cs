namespace Survey.Core
{
    /// <summary>
    /// Classe de configuração.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Status code padrão.
        /// </summary>
        public const int DefaultStatusCode = 200;

        /// <summary>
        /// Numero da pagina padrão.
        /// </summary>
        public const int DefaultPageNumber = 1;

        /// <summary>
        /// Tamanho da pagina padrão.
        /// </summary>
        public const int DefaultPageSize = 25;

        /// <summary>
        /// Endereço da aplicação do backend.
        /// </summary>
        public static string BackendUrl { get; set; } = "https://localhost:44389";

        /// <summary>
        /// Endereço da aplicação do frontend. 
        /// </summary>
        public static string FrontendUrl { get; set; } = "https://localhost:7183";

        /// <summary>
        /// Nome da aplicação mobile.
        /// </summary>
        public static string MobileName { get; set; } = "Survey.Mobile";
    }
}
