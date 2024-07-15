namespace Survey.Core.Models
{
    /// <summary>
    /// Tabela do banco de dados de bloco.
    /// </summary>
    public class Bloco
    {
        /// <summary>
        /// Indentificador do bloco.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Identificação dp levantamento.
        /// </summary>
        public long LevantamentoId { get; set; }

        /// <summary>
        /// nome do bloco.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do bloco.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Propiedade de navegação de pavimento.
        /// </summary>
        public List<Pavimento> Pavimentos { get; set; } = new List<Pavimento>();
    }
}
