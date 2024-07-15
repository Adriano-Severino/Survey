﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Survey.Api.Data;

#nullable disable

namespace Survey.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Survey.Core.Models.Bloco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR");

                    b.Property<long>("LevantamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("LevantamentoId");

                    b.ToTable("FieldDB.Blocos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 1",
                            LevantamentoId = 1L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 2L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 2",
                            LevantamentoId = 2L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 3L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 3",
                            LevantamentoId = 3L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 4L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 4",
                            LevantamentoId = 4L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 5L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 5",
                            LevantamentoId = 5L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 6L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 6",
                            LevantamentoId = 6L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 7L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 7",
                            LevantamentoId = 7L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 8L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 8",
                            LevantamentoId = 8L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 9L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 9",
                            LevantamentoId = 9L,
                            Nome = "BLOCO A"
                        },
                        new
                        {
                            Id = 10L,
                            Descricao = "BLOCO A DO LEVANTAMENTO 10",
                            LevantamentoId = 10L,
                            Nome = "BLOCO A"
                        });
                });

            modelBuilder.Entity("Survey.Core.Models.Estado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("EEstadoType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FieldDB.Estados", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Descricao = "Primeira luminária do pavimento 1",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 2L,
                            Descricao = "Primeira luminária do pavimento 2",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 3L,
                            Descricao = "Primeira luminária do pavimento 3",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 4L,
                            Descricao = "Primeira luminária do pavimento 4",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 5L,
                            Descricao = "Primeira luminária do pavimento 5",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 6L,
                            Descricao = "Primeira luminária do pavimento 6",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 7L,
                            Descricao = "Primeira luminária do pavimento 7",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 8L,
                            Descricao = "Primeira luminária do pavimento 8",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 9L,
                            Descricao = "Primeira luminária do pavimento 9",
                            EEstadoType = 0
                        },
                        new
                        {
                            Id = 10L,
                            Descricao = "Primeira luminária do pavimento 10",
                            EEstadoType = 0
                        });
                });

            modelBuilder.Entity("Survey.Core.Models.Levantamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Concluded")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("FieldDB.Levantamentos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Concluded = false,
                            Descricao = "Levantamento 1",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 2L,
                            Concluded = false,
                            Descricao = "Levantamento 2",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 3L,
                            Concluded = false,
                            Descricao = "Levantamento 3",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 4L,
                            Concluded = false,
                            Descricao = "Levantamento 4",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 5L,
                            Concluded = false,
                            Descricao = "Levantamento 5",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 6L,
                            Concluded = false,
                            Descricao = "Levantamento 6",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 7L,
                            Concluded = false,
                            Descricao = "Levantamento 7",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 8L,
                            Concluded = false,
                            Descricao = "Levantamento 8",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 9L,
                            Concluded = false,
                            Descricao = "Levantamento 9",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        },
                        new
                        {
                            Id = 10L,
                            Concluded = false,
                            Descricao = "Levantamento 10",
                            FuncionarioId = new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e")
                        });
                });

            modelBuilder.Entity("Survey.Core.Models.Luminaria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("EstadoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PavimentoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("PavimentoId");

                    b.ToTable("FieldDB.Luminarias", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EstadoId = 1L,
                            Imagem = "",
                            PavimentoId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            EstadoId = 2L,
                            Imagem = "",
                            PavimentoId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            EstadoId = 3L,
                            Imagem = "",
                            PavimentoId = 3L
                        },
                        new
                        {
                            Id = 4L,
                            EstadoId = 4L,
                            Imagem = "",
                            PavimentoId = 4L
                        },
                        new
                        {
                            Id = 5L,
                            EstadoId = 5L,
                            Imagem = "",
                            PavimentoId = 5L
                        },
                        new
                        {
                            Id = 6L,
                            EstadoId = 6L,
                            Imagem = "",
                            PavimentoId = 6L
                        },
                        new
                        {
                            Id = 7L,
                            EstadoId = 7L,
                            Imagem = "",
                            PavimentoId = 7L
                        },
                        new
                        {
                            Id = 8L,
                            EstadoId = 8L,
                            Imagem = "",
                            PavimentoId = 8L
                        },
                        new
                        {
                            Id = 9L,
                            EstadoId = 9L,
                            Imagem = "",
                            PavimentoId = 9L
                        },
                        new
                        {
                            Id = 10L,
                            EstadoId = 10L,
                            Imagem = "",
                            PavimentoId = 10L
                        });
                });

            modelBuilder.Entity("Survey.Core.Models.Pavimento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BlocoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("BlocoId");

                    b.ToTable("FieldDB.Pavimentos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BlocoId = 1L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 1 DO BLOCO 1",
                            Nome = "PAVIMENTO 1"
                        },
                        new
                        {
                            Id = 2L,
                            BlocoId = 2L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 2 DO BLOCO 2",
                            Nome = "PAVIMENTO 2"
                        },
                        new
                        {
                            Id = 3L,
                            BlocoId = 3L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 3 DO BLOCO 3",
                            Nome = "PAVIMENTO 3"
                        },
                        new
                        {
                            Id = 4L,
                            BlocoId = 4L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 4 DO BLOCO 4",
                            Nome = "PAVIMENTO 4"
                        },
                        new
                        {
                            Id = 5L,
                            BlocoId = 5L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 5 DO BLOCO 5",
                            Nome = "PAVIMENTO 5"
                        },
                        new
                        {
                            Id = 6L,
                            BlocoId = 6L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 6 DO BLOCO 6",
                            Nome = "PAVIMENTO 6"
                        },
                        new
                        {
                            Id = 7L,
                            BlocoId = 7L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 7 DO BLOCO 7",
                            Nome = "PAVIMENTO 7"
                        },
                        new
                        {
                            Id = 8L,
                            BlocoId = 8L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 8 DO BLOCO 8",
                            Nome = "PAVIMENTO 8"
                        },
                        new
                        {
                            Id = 9L,
                            BlocoId = 9L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 9 DO BLOCO 9",
                            Nome = "PAVIMENTO 9"
                        },
                        new
                        {
                            Id = 10L,
                            BlocoId = 10L,
                            Descricao = "PAVIMENTO DO LEVANTAMENTO 10 DO BLOCO 10",
                            Nome = "PAVIMENTO 10"
                        });
                });

            modelBuilder.Entity("Survey.Core.Models.Bloco", b =>
                {
                    b.HasOne("Survey.Core.Models.Levantamento", null)
                        .WithMany("Bloco")
                        .HasForeignKey("LevantamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Core.Models.Luminaria", b =>
                {
                    b.HasOne("Survey.Core.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Survey.Core.Models.Pavimento", null)
                        .WithMany("Luminarias")
                        .HasForeignKey("PavimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Survey.Core.Models.Pavimento", b =>
                {
                    b.HasOne("Survey.Core.Models.Bloco", null)
                        .WithMany("Pavimentos")
                        .HasForeignKey("BlocoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Core.Models.Bloco", b =>
                {
                    b.Navigation("Pavimentos");
                });

            modelBuilder.Entity("Survey.Core.Models.Levantamento", b =>
                {
                    b.Navigation("Bloco");
                });

            modelBuilder.Entity("Survey.Core.Models.Pavimento", b =>
                {
                    b.Navigation("Luminarias");
                });
#pragma warning restore 612, 618
        }
    }
}
