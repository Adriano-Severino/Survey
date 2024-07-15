using Microsoft.AspNetCore.Components;
using MudBlazor;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.Mobile.Components.Pages.Luminarias
{
    public class ImagemLuminariasPage : ComponentBase
    {
        #region Properties

        /// <summary>
        /// MudCarousel.
        /// </summary>
        [Parameter]
        public long Id { get; set; }
        public MudCarousel<Luminaria> _carousel;

        /// <summary>
        /// Controla quando a aplicação esta ocupado.
        /// </summary>
        public bool IsBusy { get; set; } = false;

        /// <summary>
        /// _arrows
        /// </summary>
        public bool _arrows = true;

        /// <summary>
        /// _bullets
        /// </summary>
        public bool _bullets = true;

        /// <summary>
        /// _enableSwipeGesture
        /// </summary>
        public bool _enableSwipeGesture = true;

        /// <summary>
        /// _autocycle
        /// </summary>
        public bool _autocycle = true;

        /// <summary>
        /// _source
        /// </summary>
        public List<Luminaria> _source = new List<Luminaria>();

        /// <summary>
        /// Levantamento.
        /// </summary>
        public Levantamento Levantamentos { get; set; } = new();

        /// <summary>
        /// selectedIndex
        /// </summary>
        public int selectedIndex = 2;

        #endregion

        #region Services

        /// <summary>
        /// Snackbar para mensagem do sistema.
        /// </summary>
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        /// <summary>
        /// Serviço do levantamento.
        /// </summary>
        [Inject]
        public ILevantamentoHandler levantamentoHandler { get; set; } = null!;

        #endregion

        #region Overrides

        #endregion

        #region Methods

        /// <summary>
        /// Metodo de inicialização.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            var getLevantamentoByIdRequest = new GetLevantamentoByIdRequest();
            getLevantamentoByIdRequest.Id = Id;
            IsBusy = true;
            try
            {
                var request = new GetAllLevantamentosRequest();
                var result = await levantamentoHandler.GetByIdAsync(getLevantamentoByIdRequest);
                if (result.IsSuccess)
                {
                    Levantamentos = result.Data ?? new Levantamento();

                    foreach (var bloco in Levantamentos.Bloco)
                    {
                        foreach (var pavimento in bloco.Pavimentos)
                        {
                            _source.AddRange(pavimento.Luminarias);
                        }
                    }


                }
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
    }
}
