using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Survey.Core.Models;

namespace Survey.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela bloco.
    /// </summary>
    public class BlocoMapping : IEntityTypeConfiguration<Bloco>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Bloco> builder)
        {
            builder.ToTable("FieldDB.Blocos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
             .IsRequired(true)
             .HasColumnType("NVARCHAR")
             .HasMaxLength(100);
            builder.Property(x => x.Descricao)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.HasMany(x => x.Pavimentos)
                .WithOne()
                .HasForeignKey(x => x.BlocoId);

            for (int i = 1; i <= 10; i++)
            {
                builder.HasData(new Bloco
                {
                    Id = i,
                    Descricao = $"BLOCO A DO LEVANTAMENTO {i}",
                    Nome = "BLOCO A",
                    LevantamentoId = i
                });
            }
        }
    }
}