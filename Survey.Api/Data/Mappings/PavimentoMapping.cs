using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Survey.Core.Models;

namespace Survey.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela pavimento.
    /// </summary>
    public class PavimentoMapping : IEntityTypeConfiguration<Pavimento>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Pavimento> builder)
        {
            builder.ToTable("FieldDB.Pavimentos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
               .IsRequired(true)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(100);
            builder.Property(x => x.Descricao)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.HasMany(x => x.Luminarias)
                .WithOne()
                .HasForeignKey(x => x.PavimentoId);

            for (int i = 1; i <= 10; i++)
            {
                builder.HasData(new Pavimento
                {
                    Id = i,
                    Nome = $"PAVIMENTO {i}",
                    Descricao = $"PAVIMENTO DO LEVANTAMENTO {i} DO BLOCO {i}",
                    BlocoId = i
                });
            }
        }
    }
}
