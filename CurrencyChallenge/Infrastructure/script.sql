USE [master]
GO
CREATE DATABASE [TipoCambioDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TipoCambioDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TipoCambioDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TipoCambioDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TipoCambioDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TipoCambioDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TipoCambioDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TipoCambioDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TipoCambioDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TipoCambioDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TipoCambioDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TipoCambioDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TipoCambioDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TipoCambioDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TipoCambioDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TipoCambioDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TipoCambioDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TipoCambioDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TipoCambioDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TipoCambioDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TipoCambioDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TipoCambioDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TipoCambioDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TipoCambioDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TipoCambioDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TipoCambioDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TipoCambioDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TipoCambioDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TipoCambioDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TipoCambioDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TipoCambioDB] SET  MULTI_USER 
GO
ALTER DATABASE [TipoCambioDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TipoCambioDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TipoCambioDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TipoCambioDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TipoCambioDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TipoCambioDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TipoCambioDB', N'ON'
GO
ALTER DATABASE [TipoCambioDB] SET QUERY_STORE = OFF
GO
USE [TipoCambioDB]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 03/06/2021 11:52:14 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrencyTransactions]    Script Date: 03/06/2021 11:52:14 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyTransactions](
	[CurrencyTransactionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[PurchasedAmount] [numeric](18, 2) NOT NULL,
	[TransactionDate] [date] NOT NULL,
 CONSTRAINT [PK_CurrencyTransactions] PRIMARY KEY CLUSTERED 
(
	[CurrencyTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/06/2021 11:52:14 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([Id], [Description]) VALUES (1, N'dolar')
INSERT [dbo].[Currencies] ([Id], [Description]) VALUES (2, N'real')
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
SET IDENTITY_INSERT [dbo].[CurrencyTransactions] ON 

INSERT [dbo].[CurrencyTransactions] ([CurrencyTransactionId], [UserId], [CurrencyId], [PurchasedAmount], [TransactionDate]) VALUES (1, 1, 1, CAST(10.67 AS Numeric(18, 2)), CAST(N'2021-05-30' AS Date))
INSERT [dbo].[CurrencyTransactions] ([CurrencyTransactionId], [UserId], [CurrencyId], [PurchasedAmount], [TransactionDate]) VALUES (2, 1, 1, CAST(32.00 AS Numeric(18, 2)), CAST(N'2021-05-31' AS Date))
INSERT [dbo].[CurrencyTransactions] ([CurrencyTransactionId], [UserId], [CurrencyId], [PurchasedAmount], [TransactionDate]) VALUES (3, 1, 1, CAST(10.67 AS Numeric(18, 2)), CAST(N'2021-05-31' AS Date))
SET IDENTITY_INSERT [dbo].[CurrencyTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name]) VALUES (1, N'jpalacios')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CurrencyTransactions]  WITH CHECK ADD  CONSTRAINT [FK_CurrencyTransactions_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[CurrencyTransactions] CHECK CONSTRAINT [FK_CurrencyTransactions_Currency]
GO
ALTER TABLE [dbo].[CurrencyTransactions]  WITH CHECK ADD  CONSTRAINT [FK_CurrencyTransactions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CurrencyTransactions] CHECK CONSTRAINT [FK_CurrencyTransactions_Users]
GO
USE [master]
GO
ALTER DATABASE [TipoCambioDB] SET  READ_WRITE 
GO
