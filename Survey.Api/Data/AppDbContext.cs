using Microsoft.EntityFrameworkCore;
using Survey.Core.Models;
using System.Reflection;
using static System.Reflection.Metadata.BlobBuilder;

namespace Survey.Api.Data
{
    /// <summary>
    /// SbContext da aplicação.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Contrutor do AppDbContext.
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) :
       base(options)
        { }

        /// <summary>
        /// Gerenciamento da tabela Levantamento.
        /// </summary>
        public DbSet<Levantamento> Levantamentos { get; set; } = null!;

        /// <summary>
        /// Gerenciamento da tabela Pavimento.
        /// </summary>
        public DbSet<Pavimento> Pavimentos { get; set; } = null!;

        /// <summary>
        /// Gerenciamento da tabela luminaria.
        /// </summary>
        public DbSet<Luminaria> Luminarias { get; set; } = null!;

        /// <summary>
        /// Responsavel pelo mapeamento das tabelas
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
}
