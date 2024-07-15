using Microsoft.AspNet.Identity.EntityFramework;

namespace Survey.Core.Models
{
    /// <summary>
    /// Tabela do banco de dados de funcionarios.
    /// </summary>
    public class Funcionario : IdentityUser
    {
        /// <summary>
        /// Indentificador do funcionario.
        /// </summary>
        public Guid FuncionarioId { get; set; }
    }
}