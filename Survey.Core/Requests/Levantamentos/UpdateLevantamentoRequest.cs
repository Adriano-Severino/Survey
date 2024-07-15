using Survey.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Survey.Core.Requests.Levantamentos
{
    /// <summary>
    /// Resquet de atualização do levantamento.
    /// </summary>
    public class UpdateLevantamentoRequest : Request
    {
        /// <summary>
        /// Indentificação do lenvatamento.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Descrição do levantamento.
        /// </summary>
        [Required(ErrorMessage = "Título inválido")]
        [MinLength(5, ErrorMessage = "A decrição deve conter no minimo 5 caracteres")]
        [MaxLength(500, ErrorMessage = "A decrição deve conter até 500 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Gerenciamento de concluão do levantamento.
        /// </summary>
        public bool Concluded { get; set; } = false;

        /// <summary>
        /// Lista de blocos.
        /// </summary>
        public List<Bloco> Bloco { get; set; } = new List<Bloco>();
    }
}
