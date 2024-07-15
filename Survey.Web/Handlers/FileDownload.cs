using Microsoft.AspNetCore.Components;
using Survey.Core.Handlers;

namespace Survey.Web.Handlers
{
    /// <summary>
    /// Serviço do download do apk para android.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="_navigationManager"></param>
    public class FileDownload(IHttpClientFactory httpClientFactory, NavigationManager _navigationManager) : IFileDownload
    {

        /// <summary>
        /// Serviço de cliente da requisição.
        /// </summary>
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);


        /// <summary>
        /// Metodo para fazer o download do apk para android
        /// </summary>
        /// <param name="fileName"></param>
        public async void GetFileAsync(string fileName)
        {
            try
            {
                var teste = _client.BaseAddress;
              
                _navigationManager.NavigateTo($"{_client.BaseAddress}api/v1/FileDownload/download?fileName={fileName}");
            }
            catch (Exception ex)
            {
              
            }
        }
    }
}