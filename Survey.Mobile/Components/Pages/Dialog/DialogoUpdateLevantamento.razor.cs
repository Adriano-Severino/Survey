﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;
using MudBlazor;
using Survey.Core.Enums;
using Survey.Core.Models;
using Survey.Mobile.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Survey.Mobile.Components.Pages.Dialog
{
    /// <summary>
    /// Classe de dialogo para atualizar o levantamento.
    /// </summary>
    public class DialogoUpdateLevantamentoPage : ComponentBase
    {
        #region Properties

        /// <summary>
        /// Dialogo.
        /// </summary>
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; } = new();


        /// <summary>
        /// Pavimento
        /// </summary>
        public Pavimento Pavimento { get; set; } = new();

        /// <summary>
        /// Bloco.
        /// </summary>
        [Parameter]
        public Bloco Bloco { get; set; } = new();

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
        /// Estado da luminaria funcionando ou queimado.
        /// </summary>
        public EEstadoType EstadoType { get; set; } = EEstadoType.Funcionando;

        /// <summary>
        /// Cor do botão
        /// </summary>
        [Parameter]
        public MudBlazor.Color Color { get; set; }

        /// <summary>
        /// Imagem base64.
        /// </summary>
        public string base64Image { get; set; }

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
        #endregion

        #region Overrides



        #endregion

        #region Methods

        /// <summary>
        /// Adiciona pavimento ao bloco.
        /// </summary>
        /// <returns></returns>
        public async Task AddPavimento()
        {
            Bloco.Pavimentos.Add(Pavimento);
            Snackbar.Add($"Pavimento {Pavimento.Nome} adicionado", Severity.Info);

            var resultDialog = await Dialog.ShowMessageBox(
                      "",
                      $"Deseja adicionar mais pavimento a esse bloco?",
                      cancelText: "Não",
                      yesText: "Sim");
            if (resultDialog is true)
            {
                Pavimento.Descricao = string.Empty;
                Pavimento.Nome = string.Empty;
                Pavimento.Luminarias.Clear();
                return;
            }

            MudDialog.Close(DialogResult.Ok(true));
        }

        /// <summary>
        /// Adicionar luminaria para o pavimento atual.
        /// </summary>
        public void AdicionarLuminarias()
        {
            var luminaria = new Luminaria();
            if (!string.IsNullOrWhiteSpace(base64Image) && !string.IsNullOrWhiteSpace(currentDescricao))
            {
                AdicionarLuminaria.AddAoPavimento(Pavimento, base64Image, EstadoType, Snackbar, currentDescricao);
                StateHasChanged();
            }

        }

        /// <summary>
        /// Cancela.
        /// </summary>
        public void Cancel()
        {
            MudDialog.Cancel();
        }

        /// <summary>
        /// /// Controla a expansão do método para ocultar ou mostrar.
        /// </summary>
        public void ToggleBlockFieldsBlocos()
        {
            showBlockFieldsLumianrias = !showBlockFieldsLumianrias;
        }

        /// <summary>
        /// Metodo para tirar foto com a camera.
        /// </summary>
        /// <returns></returns>
        public async Task CapturePhoto()
        {
            try
            {
                await Permissions.RequestAsync<Permissions.Camera>();

                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    Task<Stream> streamTask = photo.OpenReadAsync();

                    Stream stream = await streamTask;

                    if (stream != null)
                    {

                        using (var memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            byte[] imageBytes = memoryStream.ToArray();

                            base64Image = Convert.ToBase64String(imageBytes);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async void TakePhoto()
        {
            if (MediaPicker.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    using (var memoryStream = new MemoryStream())
                    {
                        await sourceStream.CopyToAsync(memoryStream);
                        byte[] imageBytes = memoryStream.ToArray();

                        // Converta os bytes para base64
                        var base64String = Convert.ToBase64String(imageBytes);

                        // Faça algo com a base64String (por exemplo, envie para um servidor)
                    }

                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
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
