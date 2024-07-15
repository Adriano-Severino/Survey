using System.ComponentModel.DataAnnotations;

namespace Survey.Core.Requests.Pavimentos
{
    /// <summary>
    /// Requisição de criação do pavimento.
    /// </summary>
    public class CreatePavimentoRequest : Request
    {
        /// <summary>
        /// Nome do pavimento.
        /// </summary>
        [Required(ErrorMessage = "Título inválido")]
        [MinLength(3, ErrorMessage = "A decrição deve conter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "A decrição deve conter até 500 caracteres")]
        public string Nome { get; set; }

        /// <summary>
        /// Descriáco do pavimento.
        /// </summary>
        [Required(ErrorMessage = "Título inválido")]
        [MinLength(5, ErrorMessage = "A decrição deve conter no minimo 5 caracteres")]
        [MaxLength(500, ErrorMessage = "A decrição deve conter até 500 caracteres")]
        public string Descricao { get; set; } = string.Empty;
    }
}
