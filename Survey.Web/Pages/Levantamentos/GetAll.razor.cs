using Microsoft.AspNetCore.Components;
using MudBlazor;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;

namespace Survey.Web.Pages.Levantamentos
{
    /// <summary>
    /// Pagina de para buscar todos os levantamentos.
    /// </summary>
    public partial class GetAllLevantamentosPage : ComponentBase
    {
        #region Properties

        /// <summary>
        /// Controla quando a aplicação esta ocupado.
        /// </summary>
        public bool IsBusy { get; set; } = false;

        /// <summary>
        /// Lista de levantamento.
        /// </summary>
        public List<Levantamento> Levantamentos { get; set; } = [];

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
        /// Serviço do levantamento.
        /// </summary>
        [Inject]
        public ILevantamentoHandler Handler { get; set; } = null!;

        /// <summary>
        /// Serviço de navegação.
        /// </summary>
        [Inject]
        public NavigationManager Navigation { get; set; } = null!;


        #endregion

        #region Overrides

        /// <summary>
        /// Metodo de inicialização.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllLevantamentosRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Levantamentos = result.Data ?? [];
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

        #endregion

        #region Methods

        /// <summary>
        /// Metodo para deletar o levantamento por id.
        /// </summary>
        /// <param name="id"></param>
        public async void OnDeleteButtonClickedAsync(long id)
        {
            var result = await Dialog.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir o levantamento será removida. Deseja continuar?",
                yesText: "Excluir",
                cancelText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id);

            StateHasChanged();
        }

        /// <summary>
        /// Metodo para ir para a pagina de visualização das imagem.
        /// </summary>
        /// <param name="id"></param>
        public void OnOpenImagemClickedAsync(long id)
        {
            Navigation.NavigateTo($"/imagems-luminaria/{id}");
        }

        /// <summary>
        /// Metodo de edição do levantamento.
        /// </summary>
        /// <param name="id"></param>
        public void OnEditButtonClickedAsync(long id)
        {
            Navigation.NavigateTo($"/editar/{id}");
        }

        /// <summary>
        /// Metodo para deletar o levantamento.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnDeleteAsync(long id)
        {
            try
            {
                var request = new DeleteLevantamentoRequest
                {
                    Id = id
                };
                await Handler.DeleteAsync(request);
                Levantamentos.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Levantamento removida", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
       
        #endregion
    }
}
