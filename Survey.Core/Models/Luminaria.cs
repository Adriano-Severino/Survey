namespace Survey.Core.Models
{
    /// <summary>
    /// Tabela do banco de dados da luminaria
    /// </summary>
    public class Luminaria
    {
        /// <summary>
        /// Indentificação da luminaria.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Identificação do pavimento.
        /// </summary>
        public long PavimentoId { get; set; }

        /// <summary>
        /// Identificação do estado.
        /// </summary>
        public long EstadoId { get; set; }

        /// <summary>
        /// Imagem da luminaria.
        /// </summary>
        public string Imagem { get; set; }

        /// <summary>
        /// Estado da luminaria.
        /// </summary>
        public Estado Estado { get; set; }
      
    }
}
