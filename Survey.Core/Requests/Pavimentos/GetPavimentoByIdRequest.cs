namespace Survey.Core.Requests.Pavimentos
{
    /// <summary>
    /// Requisição para buscar o pavimento por id.
    /// </summary>
    public class GetPavimentoByIdRequest : Request
    {
        public long Id { get; set; }
    }
}
