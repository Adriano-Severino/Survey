using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Survey.Core.Models;

namespace Survey.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela estado.
    /// </summary>
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("FieldDB.Estados");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);


            for (int i = 1; i <= 10; i++)
            {
                builder.HasData(new Estado
                {
                    Id = i,
                    Descricao = $"Primeira luminária do pavimento {i}",
                    EEstadoType = 0

                });
            }
        }
    }
}
