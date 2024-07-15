using Microsoft.AspNetCore.Components;
using MudBlazor;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;
using Survey.Web.Pages.Dialog;

namespace Survey.Web.Pages.Levantamentos
{
    /// <summary>
    /// Pagina de criação do levantamento.
    /// </summary>
    public partial class CreateLevantamentoPage : ComponentBase
    {
        #region Properties

        /// <summary>
        /// Controla quando a aplicação esta ocupado.
        /// </summary>
        public bool IsBusy { get; set; } = false;

        /// <summary>
        /// InputModel.
        /// </summary>
        public CreateLevantamentoRequest InputModel { get; set; } = new();

        /// <summary>
        /// Nome atual.
        /// </summary>
        public string currentNome = string.Empty;

        /// <summary>
        /// Descrição atual.
        /// </summary>
        public string currentDescricao = string.Empty;

        /// <summary>
        /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public bool showBlockFieldsBlocos = false;

        #endregion

        #region Services

        /// <summary>
        /// Serviço de levantamento.
        /// </summary>
        [Inject]
        public ILevantamentoHandler Handler { get; set; } = null!;

        /// <summary>
        /// Serviço de navegação.
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

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

        #endregion

        #region Methods

        /// <summary>
        /// Meotodo para enviar o formulario.
        /// </summary>
        /// <returns></returns>
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/levantamentos");
                }
                else
                    Snackbar.Add(result.Message, Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public void ToggleBlockFieldsBlocos()
        {
            showBlockFieldsBlocos = !showBlockFieldsBlocos;
        }

        /// <summary>
        /// Metodo para adicionar o bloco.
        /// </summary>
        /// <returns></returns>
        public async Task AddBloco()
        {
            var bloco = new Bloco();
            if (!string.IsNullOrWhiteSpace(currentNome) && !string.IsNullOrWhiteSpace(currentDescricao))
            {
                bloco.Nome = currentNome;
                bloco.Descricao = currentDescricao;
                var parameters = new DialogParameters<DialogCreatePavimento> { { x => x.Bloco, bloco }, { x => x.Color, Color.Success } };
                var result = await Dialog.ShowAsync<DialogCreatePavimento>("Adicionar Pavimento e luminaria", parameters);

                InputModel.Bloco.Add(bloco);
                if (!string.IsNullOrWhiteSpace(currentNome) || !string.IsNullOrWhiteSpace(currentDescricao))
                    Snackbar.Add($"Bloco {currentNome} adicionado", Severity.Info);

                currentNome = string.Empty;
                currentDescricao = string.Empty;
                StateHasChanged();
            }
        }

        #endregion
    }
}
