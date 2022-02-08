/****** Object:  Database [TechnicalAnalysis]    Script Date: 2/8/2022 12:11:55 PM ******/
CREATE DATABASE [TechnicalAnalysis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TechnicalAnalysis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TechnicalAnalysis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TechnicalAnalysis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TechnicalAnalysis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TechnicalAnalysis] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechnicalAnalysis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechnicalAnalysis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechnicalAnalysis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechnicalAnalysis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TechnicalAnalysis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechnicalAnalysis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET RECOVERY FULL 
GO
ALTER DATABASE [TechnicalAnalysis] SET  MULTI_USER 
GO
ALTER DATABASE [TechnicalAnalysis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechnicalAnalysis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechnicalAnalysis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechnicalAnalysis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechnicalAnalysis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TechnicalAnalysis] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TechnicalAnalysis', N'ON'
GO
ALTER DATABASE [TechnicalAnalysis] SET QUERY_STORE = OFF
GO
USE [TechnicalAnalysis]
GO
/****** Object:  User [DBUser]    Script Date: 2/8/2022 12:11:55 PM ******/
CREATE USER [DBUser] FOR LOGIN [MyTestLogin] WITH DEFAULT_SCHEMA=[db_owner]
GO
/****** Object:  Table [dbo].[ActiveMarket]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveMarket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ActiveMarket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClosePrice]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClosePrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Open] [numeric](18, 0) NOT NULL,
	[High] [numeric](18, 0) NOT NULL,
	[Low] [numeric](18, 0) NOT NULL,
	[Close] [numeric](18, 0) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_ClosePrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyPrice]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyPrice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Open] [float] NOT NULL,
	[Close] [float] NOT NULL,
	[High] [float] NOT NULL,
	[Low] [float] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_DailyPrice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] NOT NULL,
	[Age] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instrument]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instrument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[MarketId] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstrumentType]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstrumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InstrumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Market]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Market](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sector] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Market] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderItemId] [int] NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NULL,
	[OrderDate] [date] NULL,
	[CustomerId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechnicalFeature]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicalFeature](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TechnicalTypeId] [int] NOT NULL,
 CONSTRAINT [PK_TechnicalFeature] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechnicalType]    Script Date: 2/8/2022 12:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicalType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TechnicalType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ActiveMarket] ON 
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (7, 1, 1)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (8, 2, 1)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (9, 3, 0)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (10, 4, 0)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (11, 15, 0)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (12, 16, 0)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (13, 18, 1)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (14, 12, 0)
GO
INSERT [dbo].[ActiveMarket] ([Id], [InstrumentId], [Active]) VALUES (15, 14, 1)
GO
SET IDENTITY_INSERT [dbo].[ActiveMarket] OFF
GO
SET IDENTITY_INSERT [dbo].[DailyPrice] ON 
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (1, 12, 1.12331, 1.1273, 1.12787, 1.12208, CAST(N'2022-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (8, 13, 114.68, 114.398, 114.804, 114.32, CAST(N'2022-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (9, 14, 1.35249, 1.35355, 1.35556, 1.3517, CAST(N'2022-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (10, 15, 0.92102, 0.91925, 0.9222, 0.91884, CAST(N'2022-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (11, 16, 0.71294, 0.71493, 0.71541, 0.71228, CAST(N'2022-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (12, 17, 1.26824, 1.26911, 1.26994, 1.26727, CAST(N'2022-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (13, 18, 0.66388, 0.66415, 0.66494, 0.66288, CAST(N'2022-02-02T05:12:25.610' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (14, 12, 1.12351, 1.1293, 1.12807, 1.12228, CAST(N'2022-02-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (15, 13, 114.88, 114.598, 115.004, 114.52, CAST(N'2022-02-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (16, 14, 1.35349, 1.35455, 1.35656, 1.3527, CAST(N'2022-02-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (17, 15, 0.92122, 0.91945, 0.9242, 0.91904, CAST(N'2022-02-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (18, 16, 0.71394, 0.71593, 0.71641, 0.71328, CAST(N'2022-02-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (19, 17, 1.26924, 1.27011, 1.27094, 1.26827, CAST(N'2022-02-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DailyPrice] ([id], [InstrumentId], [Open], [Close], [High], [Low], [Date]) VALUES (20, 18, 0.66488, 0.66515, 0.66594, 0.66388, CAST(N'2022-02-02T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[DailyPrice] OFF
GO
INSERT [dbo].[Employee] ([EmployeeId], [Age]) VALUES (1, 18)
GO
INSERT [dbo].[Employee] ([EmployeeId], [Age]) VALUES (2, 18)
GO
INSERT [dbo].[Employee] ([EmployeeId], [Age]) VALUES (3, 22)
GO
INSERT [dbo].[Employee] ([EmployeeId], [Age]) VALUES (4, 50)
GO
INSERT [dbo].[Employee] ([EmployeeId], [Age]) VALUES (5, 18)
GO
SET IDENTITY_INSERT [dbo].[Instrument] ON 
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (1, N'/ES', N'E-Mini S&P 500', 1, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (2, N'/NQ', N'E-mini NASDAQ 100', 1, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (3, N'/RTY', N'E-mini Russell 2000 Index', 1, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (4, N'/YM', N'E-mini Dow', 1, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (5, N'6B', N'British Pound FX', 2, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (6, N'6E', N'Euro FX', 2, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (7, N'DX', N'US Dollar Index', 2, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (8, N'GC', N'Gold', 3, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (9, N'SI', N'Silver', 3, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (10, N'CL', N'Crude Oil', 4, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (11, N'ZB', N'US 30-Year Treasury Bonds', 5, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (12, N'EUR/USD', N'Euro/US Dollar', 6, 1)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (13, N'USD/JPY', N'US Dollar/Yen', 6, 1)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (14, N'GBP/USD', N'Pound/US Dollar', 6, 1)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (15, N'USD/CHF', N'US Dollar/Swiss franc', 6, 1)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (16, N'AUD/USD', N'Aussie Dollar/US Ddollar', 6, 1)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (17, N'USD/CAD', N'US Dollar/Canadian Dollar', 6, 1)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (18, N'NZD/USD', N'Kiwi/Canadian Dollar', 6, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (19, N'EUR/GBP', N'Euro/Pound', 7, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (20, N'AUD/JPY', N'Aussie Dollar/Yen', 7, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (21, N'EUR/JPY', N'Euro/Yen', 7, 0)
GO
INSERT [dbo].[Instrument] ([Id], [Symbol], [Description], [MarketId], [Active]) VALUES (22, N'GBP/JPY', N'Pound/Yen', 7, 0)
GO
SET IDENTITY_INSERT [dbo].[Instrument] OFF
GO
SET IDENTITY_INSERT [dbo].[InstrumentType] ON 
GO
INSERT [dbo].[InstrumentType] ([Id], [Name]) VALUES (1, N'Futures')
GO
INSERT [dbo].[InstrumentType] ([Id], [Name]) VALUES (2, N'Stocks')
GO
INSERT [dbo].[InstrumentType] ([Id], [Name]) VALUES (3, N'Forex')
GO
SET IDENTITY_INSERT [dbo].[InstrumentType] OFF
GO
SET IDENTITY_INSERT [dbo].[Market] ON 
GO
INSERT [dbo].[Market] ([Id], [Name], [Sector]) VALUES (1, N'Futures', N'Index')
GO
INSERT [dbo].[Market] ([Id], [Name], [Sector]) VALUES (2, N'Futures', N'Currency')
GO
INSERT [dbo].[Market] ([Id], [Name], [Sector]) VALUES (3, N'Futures', N'Metal')
GO
INSERT [dbo].[Market] ([Id], [Name], [Sector]) VALUES (4, N'Futures', N'Energy')
GO
INSERT [dbo].[Market] ([Id], [Name], [Sector]) VALUES (5, N'Futures', N'Interest Rate')
GO
INSERT [dbo].[Market] ([Id], [Name], [Sector]) VALUES (6, N'Forex', N'Major')
GO
INSERT [dbo].[Market] ([Id], [Name], [Sector]) VALUES (7, N'Forex', N'Minor')
GO
SET IDENTITY_INSERT [dbo].[Market] OFF
GO
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderId], [ProductId], [Quantity]) VALUES (1, 1, 2, 4)
GO
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderId], [ProductId], [Quantity]) VALUES (1, 1, 3, 54)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [CustomerId]) VALUES (1, CAST(N'2022-01-22' AS Date), 1)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [CustomerId]) VALUES (2, CAST(N'2022-01-23' AS Date), 2)
GO
SET IDENTITY_INSERT [dbo].[TechnicalFeature] ON 
GO
INSERT [dbo].[TechnicalFeature] ([id], [Name], [TechnicalTypeId]) VALUES (1, N'Woodie', 1)
GO
INSERT [dbo].[TechnicalFeature] ([id], [Name], [TechnicalTypeId]) VALUES (2, N'Camarilla', 1)
GO
SET IDENTITY_INSERT [dbo].[TechnicalFeature] OFF
GO
SET IDENTITY_INSERT [dbo].[TechnicalType] ON 
GO
INSERT [dbo].[TechnicalType] ([Id], [Name]) VALUES (1, N'Pivot')
GO
SET IDENTITY_INSERT [dbo].[TechnicalType] OFF
GO
ALTER TABLE [dbo].[ClosePrice]  WITH CHECK ADD  CONSTRAINT [FK_ClosePrice_Instrument] FOREIGN KEY([Id])
REFERENCES [dbo].[Instrument] ([Id])
GO
ALTER TABLE [dbo].[ClosePrice] CHECK CONSTRAINT [FK_ClosePrice_Instrument]
GO
ALTER TABLE [dbo].[DailyPrice]  WITH CHECK ADD  CONSTRAINT [FK_DailyPrice_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [dbo].[Instrument] ([Id])
GO
ALTER TABLE [dbo].[DailyPrice] CHECK CONSTRAINT [FK_DailyPrice_Instrument]
GO
ALTER TABLE [dbo].[Instrument]  WITH CHECK ADD  CONSTRAINT [FK_Instrument_Market] FOREIGN KEY([MarketId])
REFERENCES [dbo].[Market] ([Id])
GO
ALTER TABLE [dbo].[Instrument] CHECK CONSTRAINT [FK_Instrument_Market]
GO
/****** Object:  StoredProcedure [dbo].[GetOrdersAfterDate]    Script Date: 2/8/2022 12:11:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrdersAfterDate] 
	@OrderDate DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT OrderId, OrderDate, CustomerId FROM Orders
	WHERE OrderDate > @OrderDate
END
GO
USE [master]
GO
ALTER DATABASE [TechnicalAnalysis] SET  READ_WRITE 
GO
