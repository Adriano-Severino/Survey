namespace Survey.Core.Requests.Luminarias
{
    /// <summary>
    /// Requisição de deletar a luminaria.
    /// </summary>
    public class DeleteLuminariaRequest : Request
    {

        public long Id { get; set; }
    }
}
