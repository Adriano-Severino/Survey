using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Survey.Core.Enums;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;
using Survey.Core.Requests.Pavimentos;
using Survey.Web.Pages.Dialog;

namespace Survey.Web.Pages.Levantamentos
{
    public partial class UpdateLevantamentoPage : ComponentBase
    {
        #region Properties

        /// <summary>
        /// Controla quando a aplicação esta ocupado.
        /// </summary>
        public bool IsBusy { get; set; } = false;

        /// <summary>
        /// Levantamento.
        /// </summary>
        public Levantamento Levantamento { get; set; } = new();

        /// <summary>
        /// Identificação do levantamento.
        /// </summary>
        [Parameter]
        public long Id { get; set; }

        /// <summary>
        /// InputModel
        /// </summary>
        public UpdateLevantamentoRequest InputModel { get; set; } = new();

        /// <summary>
        /// Pavimento.
        /// </summary>
        public Pavimento Pavimento = new();

         /// <summary>
        /// Nome atual.
        /// </summary>
        public string currentImagem = string.Empty;

        /// <summary>
        /// Descrição atual.
        /// </summary>
        public string currentDescricao = string.Empty;

        /// <summary>
        /// Nome atual.
        /// </summary>
        public string currentNome = string.Empty;

        /// <summary>
        /// Controla a conclusão do levantamento.
        /// </summary>
        public bool Concluded { get; set; } = false;

        /// <summary>
        /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public bool showBlockFieldsPagimento = false;

        /// <summary>
        /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public bool showBlockFieldsBlocos = false;

        /// <summary>
        /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public bool showBlockFieldsNovoBlocos = false;

        /// <summary>
        /// Imagem base64.
        /// </summary>
        public string base64Image;

        /// <summary>
        /// Estado da luminaria funcionando ou queimado.
        /// </summary>
        public EEstadoType EstadoType { get; set; } = EEstadoType.Funcionando;

        /// <summary>
        /// Cor do botão.
        /// </summary>
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
        /// Serviço do levantamento.
        /// </summary>
        [Inject]
        public ILevantamentoHandler LevantamentoHandler { get; set; } = null!;

        /// <summary>
        /// Serviço do pavimento.
        /// </summary>
        [Inject]
        public IPavimentoHandler PavimentoHandler { get; set; } = null!;

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
                var request = new GetLevantamentoByIdRequest();
                request.Id = Id;
                var result = await LevantamentoHandler.GetByIdAsync(request);
                if (result.IsSuccess)
                    Levantamento = result.Data ?? new Levantamento();

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
        /// Meotodo para enviar o formulario.
        /// </summary>
        /// <returns></returns>
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                InputModel.Id = Levantamento.Id;
                InputModel.Descricao = Levantamento.Descricao;
                InputModel.Concluded = Levantamento.Concluded;
                InputModel.FuncionarioId = Levantamento.FuncionarioId;
                InputModel.Bloco = Levantamento.Bloco;

                var result = await LevantamentoHandler.UpdateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    Navigation.NavigateTo("/levantamentos");
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
        public void ToggleBlockFieldsNovoBlocos()
        {
            showBlockFieldsNovoBlocos = !showBlockFieldsNovoBlocos;
        }

        /// <summary>
        /// /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public void ToggleBlockFieldsBlocos()
        {
            showBlockFieldsBlocos = !showBlockFieldsBlocos;
        }

        /// <summary>
        /// /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public void ToggleBlockFieldsPavimento()
        {
            showBlockFieldsPagimento = !showBlockFieldsPagimento;
        }

        /// <summary>
        /// Metodo para adionar bloco ao lenvatamento.
        /// </summary>
        /// <returns></returns>
        public async Task AddBloco()
        {
            var bloco = new Bloco();

            if (!string.IsNullOrWhiteSpace(currentNome) && !string.IsNullOrWhiteSpace(currentDescricao))
            {
                bloco.Descricao = currentDescricao;
                bloco.Nome = currentNome;

                var resultDialog = await Dialog.ShowMessageBox(
                    "",
                    $"Deseja adicionar pavimento a esse bloco?",
                    cancelText: "Não",
                    yesText: "Sim");

                if (resultDialog is true)
                {
                    var parameters = new DialogParameters<DialogCreatePavimento> { { x => x.Bloco, bloco }, { x => x.Color, Color.Success } };
                    var result = await Dialog.ShowAsync<DialogCreatePavimento>("Adicionar Pavimento e luminaria", parameters);


                }
                Levantamento.Bloco.Add(bloco);
                if (!string.IsNullOrWhiteSpace(currentNome) || !string.IsNullOrWhiteSpace(currentDescricao))
                    Snackbar.Add($"Bloco {currentNome} adicionado", Severity.Info);

                currentNome = string.Empty;
                currentDescricao = string.Empty;

            }

        }

        /// <summary>
        /// Cancela
        /// </summary>
        public void Cancel()
        {
            Navigation.NavigateTo("/levantamentos");
        }


        /// <summary>
        /// Metodo para adionar pavimento ao bloco.
        /// </summary>
        /// <param name="bloco"></param>
        /// <returns></returns>
        public async Task AddPavimento(Bloco bloco)
        {
            var parameters = new DialogParameters<DialogCreatePavimento> { { x => x.Bloco, bloco }, { x => x.Color, Color.Success } };
            var result = await Dialog.ShowAsync<DialogCreatePavimento>("Adicionar Pavimento e luminaria", parameters);
            Snackbar.Add($"Pavimento adicionado", Severity.Info);
            StateHasChanged();
        }

        /// <summary>
        /// Metodo para atualizar o pavimento.
        /// </summary>
        /// <param name="pavimento"></param>
        /// <returns></returns>
        public async Task AtualizarPavimento(Pavimento pavimento)
        {
            IsBusy = true;

            try
            {
                var pavimentoUpdate = new UpdatePavimentoRequest();

                pavimentoUpdate.Descricao = pavimento.Descricao;
                pavimentoUpdate.Nome = pavimento.Nome;
                pavimentoUpdate.Id = pavimento.Id;

                var result = await PavimentoHandler.UpdateAsync(pavimentoUpdate);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    StateHasChanged();
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
        /// Metodo para atualizar a liminaria.
        /// </summary>
        /// <param name="pavimento"></param>
        /// <returns></returns>
        public async Task EditarLuminarias(Pavimento pavimento)
        {
            var parameters = new DialogParameters<DialogUpdateLuminaria> { { x => x.Pavimento, pavimento }, { x => x.FuncionarioId, Levantamento.FuncionarioId }, { x => x.Color, Color.Success } };
            var result = await Dialog.ShowAsync<DialogUpdateLuminaria>("Adicionar Pavimento e luminaria", parameters);

            if (!string.IsNullOrWhiteSpace(currentNome) || !string.IsNullOrWhiteSpace(currentDescricao))
                Snackbar.Add($"Lumianrias atualizadas", Severity.Info);
            return;
        }

        #endregion
    }
}
