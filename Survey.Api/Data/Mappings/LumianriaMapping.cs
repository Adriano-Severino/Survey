using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Survey.Core.Models;

namespace Survey.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela luminaria.
    /// </summary>
    public class LumianriaMapping : IEntityTypeConfiguration<Luminaria>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Luminaria> builder)
        {
            builder.ToTable("FieldDB.Luminarias");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Estado)
                .WithMany()
                .HasForeignKey(x => x.EstadoId);

            for (int i = 1; i <=10; i++)
            {
                builder.HasData(new Luminaria
                {
                    Id = i,
                    Imagem = "",
                    PavimentoId = i,
                    EstadoId = i
                });
            }
           
        }
    }
}