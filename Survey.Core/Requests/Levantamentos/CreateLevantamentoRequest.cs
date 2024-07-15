using Survey.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Survey.Core.Requests.Levantamentos
{
    /// <summary>
    /// Request de criaçao do levantamento.
    /// </summary>
    public class CreateLevantamentoRequest : Request
    {
        /// <summary>
        /// Descrição do levantamento
        /// </summary>
        [Required(ErrorMessage = "Título inválido")]
        [MinLength(5, ErrorMessage = "A decrição deve conter no minimo 5 caracteres")]
        [MaxLength(500, ErrorMessage = "A decrição deve conter até 500 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Lista dos blocos.
        /// </summary>
        public List<Bloco> Bloco { get; set; } = new List<Bloco>();

    }
}
