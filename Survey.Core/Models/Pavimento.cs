namespace Survey.Core.Models
{
    /// <summary>
    /// Tabela do banco de dados do pavimento
    /// </summary>
    public class Pavimento
    {
        /// <summary>
        /// Indentificação do pavimento.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Identificação do bloco
        /// </summary>
        public long BlocoId { get; set; }

        /// <summary>
        /// Nome do pavimento.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

     
        /// <summary>
        /// Descrição do pavimento.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Propiedade de navegação da luminaria.
        /// </summary>
        public List<Luminaria> Luminarias { get; set; } = new List<Luminaria>();
       
    }
}
