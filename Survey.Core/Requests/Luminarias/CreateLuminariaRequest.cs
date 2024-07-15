using Survey.Core.Models;

namespace Survey.Core.Requests.Luminarias
{
    /// <summary>
    /// Requisição de criação da luminaria
    /// </summary>
    public class CreateLuminariaRequest : Request
    {
        /// <summary>
        /// Imagem da luminaria.
        /// </summary>
        public string Imagem { get; set; } = string.Empty;

        /// <summary>
        /// Estado da liminaria.
        /// </summary>
        public Estado Estado { get; set; }
    }
}
