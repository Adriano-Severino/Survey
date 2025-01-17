USE [master]
GO
/****** Object:  Database [Survey]    Script Date: 12/07/2024 16:07:59 ******/
CREATE DATABASE [Survey]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Survey', FILENAME = N'/var/opt/mssql/data/Survey.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Survey_log', FILENAME = N'/var/opt/mssql/data/Survey_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Survey] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Survey].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Survey] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Survey] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Survey] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Survey] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Survey] SET ARITHABORT OFF 
GO
ALTER DATABASE [Survey] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Survey] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Survey] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Survey] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Survey] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Survey] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Survey] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Survey] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Survey] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Survey] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Survey] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Survey] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Survey] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Survey] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Survey] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Survey] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Survey] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Survey] SET RECOVERY FULL 
GO
ALTER DATABASE [Survey] SET  MULTI_USER 
GO
ALTER DATABASE [Survey] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Survey] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Survey] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Survey] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Survey] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Survey] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Survey', N'ON'
GO
ALTER DATABASE [Survey] SET QUERY_STORE = ON
GO
ALTER DATABASE [Survey] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Survey]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/07/2024 16:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldDB.Blocos]    Script Date: 12/07/2024 16:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDB.Blocos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LevantamentoId] [bigint] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_FieldDB.Blocos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldDB.Estados]    Script Date: 12/07/2024 16:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDB.Estados](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[EEstadoType] [int] NOT NULL,
 CONSTRAINT [PK_FieldDB.Estados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldDB.Levantamentos]    Script Date: 12/07/2024 16:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDB.Levantamentos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FuncionarioId] [uniqueidentifier] NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Concluded] [bit] NOT NULL,
 CONSTRAINT [PK_FieldDB.Levantamentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldDB.Luminarias]    Script Date: 12/07/2024 16:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDB.Luminarias](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PavimentoId] [bigint] NOT NULL,
	[EstadoId] [bigint] NOT NULL,
	[Imagem] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FieldDB.Luminarias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldDB.Pavimentos]    Script Date: 12/07/2024 16:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDB.Pavimentos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BlocoId] [bigint] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_FieldDB.Pavimentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_FieldDB.Blocos_LevantamentoId]    Script Date: 12/07/2024 16:08:00 ******/
CREATE NONCLUSTERED INDEX [IX_FieldDB.Blocos_LevantamentoId] ON [dbo].[FieldDB.Blocos]
(
	[LevantamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FieldDB.Luminarias_EstadoId]    Script Date: 12/07/2024 16:08:00 ******/
CREATE NONCLUSTERED INDEX [IX_FieldDB.Luminarias_EstadoId] ON [dbo].[FieldDB.Luminarias]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FieldDB.Luminarias_PavimentoId]    Script Date: 12/07/2024 16:08:00 ******/
CREATE NONCLUSTERED INDEX [IX_FieldDB.Luminarias_PavimentoId] ON [dbo].[FieldDB.Luminarias]
(
	[PavimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FieldDB.Pavimentos_BlocoId]    Script Date: 12/07/2024 16:08:00 ******/
CREATE NONCLUSTERED INDEX [IX_FieldDB.Pavimentos_BlocoId] ON [dbo].[FieldDB.Pavimentos]
(
	[BlocoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FieldDB.Blocos]  WITH CHECK ADD  CONSTRAINT [FK_FieldDB.Blocos_FieldDB.Levantamentos_LevantamentoId] FOREIGN KEY([LevantamentoId])
REFERENCES [dbo].[FieldDB.Levantamentos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldDB.Blocos] CHECK CONSTRAINT [FK_FieldDB.Blocos_FieldDB.Levantamentos_LevantamentoId]
GO
ALTER TABLE [dbo].[FieldDB.Luminarias]  WITH CHECK ADD  CONSTRAINT [FK_FieldDB.Luminarias_FieldDB.Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[FieldDB.Estados] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldDB.Luminarias] CHECK CONSTRAINT [FK_FieldDB.Luminarias_FieldDB.Estados_EstadoId]
GO
ALTER TABLE [dbo].[FieldDB.Luminarias]  WITH CHECK ADD  CONSTRAINT [FK_FieldDB.Luminarias_FieldDB.Pavimentos_PavimentoId] FOREIGN KEY([PavimentoId])
REFERENCES [dbo].[FieldDB.Pavimentos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldDB.Luminarias] CHECK CONSTRAINT [FK_FieldDB.Luminarias_FieldDB.Pavimentos_PavimentoId]
GO
ALTER TABLE [dbo].[FieldDB.Pavimentos]  WITH CHECK ADD  CONSTRAINT [FK_FieldDB.Pavimentos_FieldDB.Blocos_BlocoId] FOREIGN KEY([BlocoId])
REFERENCES [dbo].[FieldDB.Blocos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldDB.Pavimentos] CHECK CONSTRAINT [FK_FieldDB.Pavimentos_FieldDB.Blocos_BlocoId]
GO
USE [master]
GO
ALTER DATABASE [Survey] SET  READ_WRITE 

USE [Survey]
GO

SET IDENTITY_INSERT [dbo].[FieldDB.Levantamentos] ON;

-- Inserir dados na tabela Levantamentos
INSERT INTO [dbo].[FieldDB.Levantamentos] (Id, Descricao, Concluded, FuncionarioId)
VALUES (1, 'Levantamento 1', 0, '206D0FCC-EA9A-4164-9C38-C48B18451E1E');

SET IDENTITY_INSERT [dbo].[FieldDB.Levantamentos] OFF;
SET IDENTITY_INSERT [dbo].[FieldDB.Blocos] ON;

-- Inserir dados na tabela Blocos
INSERT INTO [dbo].[FieldDB.Blocos] (Id, Descricao, Nome, LevantamentoId)
VALUES (1, 'BLOCO A DO LEVANTAMENTO 1', 'BLOCO A', 1);

SET IDENTITY_INSERT [dbo].[FieldDB.Blocos] OFF;
SET IDENTITY_INSERT [dbo].[FieldDB.Pavimentos] ON;

-- Inserir dados na tabela Pavimentos
INSERT INTO [dbo].[FieldDB.Pavimentos] (Id, BlocoId, Nome, Descricao)
VALUES (1, 1, 'PAVIMENTO 1', 'PAVIMENTO DO LEVANTAMENTO 1 DO BLOCO 1');

SET IDENTITY_INSERT [dbo].[FieldDB.Pavimentos] OFF;
SET IDENTITY_INSERT [dbo].[FieldDB.Luminarias] ON;

-- Inserir dados na tabela Luminarias
INSERT INTO [dbo].[FieldDB.Luminarias] (Id, EstadoId, Imagem, PavimentoId)
VALUES (1, 1, 'string', 1);

SET IDENTITY_INSERT [dbo].[FieldDB.Luminarias] OFF;
SET IDENTITY_INSERT [dbo].[FieldDB.Estados] ON;

-- Inserir dados na tabela Estados
INSERT INTO [dbo].[FieldDB.Estados] (Id, Descricao, EEstadoType)
VALUES (1, 'Primeira luminária do pavimento 1', 0);

SET IDENTITY_INSERT [dbo].[FieldDB.Estados] OFF;
