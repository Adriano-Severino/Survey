using Survey.Core.Models;

namespace Survey.Core.Requests.Luminarias
{
    /// <summary>
    /// Requisição de atualização da luminaria
    /// </summary>
    public class UpdateLuminariaRequest : Request
    {
        /// <summary>
        /// Identificação da luminaria.
        /// </summary>
        public long Id { get; set; }

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
