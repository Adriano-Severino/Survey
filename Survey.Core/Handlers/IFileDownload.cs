namespace Survey.Core.Handlers
{
    /// <summary>
    /// Interface do serviço de download
    /// </summary>
    public interface IFileDownload
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public void GetFileAsync(string fileName);
    }
}
