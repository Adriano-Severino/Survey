namespace Survey.Api
{
    /// <summary>
    /// Configuração da api.
    /// </summary>
    public class ApiConfiguration
    {
        /// <summary>
        /// Guid do funcionario logado no sistema.
        /// </summary>
        public static Guid FuncionarioId =  new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E");

        /// <summary>
        /// Cadeia de conexão do bando de dados
        /// </summary>
        public static string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// Nomme do cors.
        /// </summary>
        public static string CorsPolicyName = "wasm";
    }
}
