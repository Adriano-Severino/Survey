using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Survey.Core.Models;

namespace Survey.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela levantamento.
    /// </summary>
    public class LevantamentoMapping : IEntityTypeConfiguration<Levantamento>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Levantamento> builder)
        {
            builder.ToTable("FieldDB.Levantamentos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.HasMany(x => x.Bloco)
                .WithOne()
                .HasForeignKey(x => x.LevantamentoId);

            for (int i = 1; i <= 10; i++)
            {
                builder.HasData(new Levantamento
                {
                    Id = i,
                    Descricao = $"Levantamento {i}",
                    Concluded = false,
                    FuncionarioId = new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E")

                });
            }


        }
    }
}
