using Survey.Core.Models;

namespace Survey.Api.Data
{
    public static class DataSeede
    {
        private static List<Levantamento> Levantamentos { get; } = new List<Levantamento>();
        private static List<Bloco> Blocos { get; } = new List<Bloco>();
        private static List<Pavimento> Pavimetos { get; } = new List<Pavimento>();
        private static List<Luminaria> Luminarias { get; } = new List<Luminaria>();
        private static List<Estado> Estados { get; } = new List<Estado>();
        static DataSeede()
        {
            SeedeLevantamento();
            SeedBlocos();
            SeedPavimento();
            SeedLuminaria();
            SeedEstado();
        }
        public static void SeedeLevantamento()
        {
            Levantamentos.AddRange(new[]
            {
                new Levantamento
            {
                Id = 1,
                Descricao = "Levantamento 1",
                Concluded = false,
                FuncionarioId = new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E")

            }
            });
        }

        public static void SeedBlocos()
        {
            Blocos.AddRange(new[]
            {
                new Bloco
            {
                Id = 1,
                Descricao = "BLOCO A DO LEVANTAMENTO 1",
                Nome = "BLOCO A",
                LevantamentoId = 1
            }
            });

        }

        public static void SeedPavimento()
        {
            Pavimetos.AddRange(new[]
            {
                new Pavimento
            {
                Id=1,
                Nome = "PAVIMENTO 1",
                Descricao = "PAVIMENTO DO LEVANTAMENTO 1 DO BLOCO 1",
                BlocoId= 1


            }
            });
        }

        public static void SeedLuminaria()
        {
            Luminarias.AddRange(new[]
            {
              new Luminaria
            {
                Id = 1,
                Imagem = "",
                PavimentoId = 1,EstadoId = 1



            }
            });
        }

        public static void SeedEstado()
        {
            Estados.AddRange(new[]
           {new Estado
            {
                Id = 1,
                Descricao = "Primeira luminária do pavimento 1",
                EEstadoType = 0

            }

            });

        }
    }
}