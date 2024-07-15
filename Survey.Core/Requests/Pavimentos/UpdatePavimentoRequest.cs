using System.ComponentModel.DataAnnotations;

namespace Survey.Core.Requests.Pavimentos
{
    /// <summary>
    /// Requisição para atualizar o pavimento.
    /// </summary>
    public class UpdatePavimentoRequest : Request
    {
        /// <summary>
        /// Identificação do pavimento.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome do pavimento.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do pavimento
        /// </summary>
        [Required(ErrorMessage = "Título inválido")]
        [MinLength(5, ErrorMessage = "A decrição deve conter no minimo 5 caracteres")]
        [MaxLength(500, ErrorMessage = "A decrição deve conter até 500 caracteres")]
        public string Descricao { get; set; } = string.Empty;
    }
}