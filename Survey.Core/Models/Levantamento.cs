namespace Survey.Core.Models
{
    /// <summary>
    /// Tabela do banco de dados de levantamento.
    /// </summary>
    public class Levantamento
    {
        /// <summary>
        /// Indentificador do levantamento
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Indentificador do funcionario.
        /// </summary>
        public Guid FuncionarioId { get; set; }

        /// <summary>
        /// Descrição do levantamento.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Para gerenciamento da clonclusão do levantamento.
        /// </summary>
        public bool Concluded { get; set; } = false;

        /// <summary>
        /// Propiedade de navegação do bloco.
        /// </summary>
        public List<Bloco> Bloco { get; set; } = new List<Bloco>();
    }
}
