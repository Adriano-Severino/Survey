using Survey.Core.Enums;

namespace Survey.Core.Models
{
    /// <summary>
    /// Tabela do banco de dados de estado da luminaria.
    /// </summary>
    public class Estado
    {
        /// <summary>
        /// Indentificador do estado da luminaria.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Descricao do estado da luminaria.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Enum funcionando ou queimado.
        /// </summary>
        public EEstadoType EEstadoType { get; set; }
    }
}
