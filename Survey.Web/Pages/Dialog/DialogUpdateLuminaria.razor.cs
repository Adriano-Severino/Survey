using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Survey.Core.Enums;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Luminarias;
using Survey.Web.Helpers;

namespace Survey.Web.Pages.Dialog
{
    /// <summary>
    /// Classe de dialogo para atualizar a luminaria.
    /// </summary>
    public class DialogUpdateLuminariaPage : ComponentBase
    {
        #region Properties

        /// <summary>
        /// Dialogo.
        /// </summary>
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; } = new();

        /// <summary>
        /// Pavimento.
        /// </summary>
        [Parameter]
        public Pavimento Pavimento { get; set; } = new();

        /// <summary>
        /// Imagem atual.
        /// </summary>
        public string currentImagem = string.Empty;

        /// <summary>
        /// Descrição atual.
        /// </summary>
        public string currentDescricao = string.Empty;

        /// <summary>
        /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public bool showBlockFieldsLumianrias = false;

        /// <summary>
        /// Imagem base64.
        /// </summary>
        public string base64Image { get; set; }

        /// <summary>
        /// Identificação do funcionario
        /// </summary>
        [Parameter]
        public Guid FuncionarioId { get; set; } = new();

        /// <summary>
        /// Estado da luminaria funcionando ou queimado.
        /// </summary>
        public EEstadoType EstadoType { get; set; } = EEstadoType.Funcionando;

        /// <summary>
        /// Cor do botão.
        /// </summary>
        [Parameter]
        public Color Color { get; set; }


        #endregion

        #region Services

        /// <summary>
        /// Snackbar para mensagem do sistema.
        /// </summary>
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        /// <summary>
        /// Serviço de dialogo.
        /// </summary>
        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        /// <summary>
        /// Serviço da luminaria.
        /// </summary>
        [Inject]
        public ILuminariaHandler luminariaHandler { get; set; } = null!;

        #endregion

        #region Overrides



        #endregion

        #region Methods


        /// <summary>
        /// Atualiza a luminaria do pavimento atual.
        /// </summary>
        public async Task UpdateLuminarias(Luminaria luminaria)
        {
            luminaria.Imagem = base64Image;
            luminaria.Estado.Descricao = currentDescricao;
            foreach (var luminariaAtual in Pavimento.Luminarias)
            {
                if (luminariaAtual.Id == luminaria.Id)
                {
                    luminariaAtual.Estado = luminaria.Estado;
                    luminariaAtual.Imagem = luminaria.Imagem;
                    luminariaAtual.Estado.EEstadoType = EstadoType;
                    luminariaAtual.Estado.Descricao = luminaria.Estado.Descricao;

                    var LuminariaUpdate = new UpdateLuminariaRequest();
                    LuminariaUpdate.Id = luminaria.Id;
                    LuminariaUpdate.Estado = luminariaAtual.Estado;
                    LuminariaUpdate.Imagem = luminariaAtual.Imagem;
                    LuminariaUpdate.Estado = luminariaAtual.Estado;
                    LuminariaUpdate.FuncionarioId = FuncionarioId;

                    await luminariaHandler.UpdateAsync(LuminariaUpdate);
                }
            }
            Snackbar.Add($"Luminaria Atualizada", Severity.Info);
            currentDescricao = string.Empty;
            MudDialog.Close(DialogResult.Ok(true));

        }

        /// <summary>
        /// Adiciona luminaria ao pavimento.
        /// </summary>
        /// <returns></returns>
        public async Task AddLuminarias()
        {
            var luminaria = new Luminaria();
            if (!string.IsNullOrWhiteSpace(base64Image) && !string.IsNullOrWhiteSpace(currentDescricao))
            {
                AdicionarLuminaria.AddAoPavimento(Pavimento, base64Image, EstadoType, Snackbar, currentDescricao);
                StateHasChanged();
            }

        }

        /// <summary>
        /// /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public void ToggleBlockFieldsBlocos()
        {
            showBlockFieldsLumianrias = !showBlockFieldsLumianrias;
        }

        /// <summary>
        /// Cancela
        /// </summary>
        public void Fechar()
        {
            MudDialog.Cancel();
        }

        /// <summary>
        /// Faz o upload da imagem.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task HandleFileChange(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file.Size > 1024 * 1024)
            {
                var result = await Dialog.ShowMessageBox(
                    "ATENÇÃO",
                    $"O tamanho maximo permitido para as imagem é de 1 megabits",
                    yesText: "Ok");
                return;
            }

            var buffer = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffer);

            if (file.Name != currentImagem)
            {
                base64Image = null;
            }

            base64Image = $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";
            currentImagem = file.Name;
        }

        #endregion
    }
}
