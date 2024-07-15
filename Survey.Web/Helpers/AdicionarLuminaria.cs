using MudBlazor;
using Survey.Core.Enums;
using Survey.Core.Models;

namespace Survey.Web.Helpers
{
    /// <summary>
    /// Classe para adicionar luminaria.
    /// </summary>
    public static class AdicionarLuminaria
    {
        /// <summary>
        /// Metodo para adicionar uma luminaria.
        /// </summary>
        /// <param name="pavimento"></param>
        /// <param name="base64Image"></param>
        /// <param name="eEstadoType"></param>
        /// <param name="snackbar"></param>
        /// <param name="currentDescricao"></param>
        public static void AddAoPavimento(Pavimento pavimento, string base64Image, EEstadoType eEstadoType, ISnackbar snackbar, string currentDescricao)
        {
            var luminaria = new Luminaria();
            luminaria.Imagem = base64Image;
            luminaria.Estado = new Estado { Descricao = currentDescricao, EEstadoType = eEstadoType };
            pavimento.Luminarias.Add(luminaria);
            snackbar.Add($"Luminaria adicionada", Severity.Info);
            currentDescricao = string.Empty;

        }

    }
}
