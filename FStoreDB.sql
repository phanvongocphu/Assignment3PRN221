USE [master]
GO
/****** Object:  Database [FStoreDB]    Script Date: 10/30/2024 3:21:00 PM ******/
CREATE DATABASE [FStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NGOCPHU\MSSQL\DATA\FStoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NGOCPHU\MSSQL\DATA\FStoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FStoreDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FStoreDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FStoreDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FStoreDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FStoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [FStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FStoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FStoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FStoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FStoreDB] SET QUERY_STORE = OFF
GO
USE [FStoreDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/30/2024 3:21:00 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 10/30/2024 3:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 10/30/2024 3:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/30/2024 3:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [real] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/30/2024 3:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[RequiredDate] [datetime2](7) NULL,
	[ShippedDate] [datetime2](7) NULL,
	[Freight] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/30/2024 3:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Weight] [nvarchar](max) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[UnitInStock] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241023045756__phu', N'6.0.1')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Basic')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Modern')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([MemberId], [Email], [CompanyName], [City], [Country], [Password], [Role]) VALUES (1, N'admin@gmail.com', N'FPTU', N'HCM', N'Vietnam', N'123', N'Admin')
INSERT [dbo].[Members] ([MemberId], [Email], [CompanyName], [City], [Country], [Password], [Role]) VALUES (2, N'user@gmail.com', N'Haha', N'HCM', N'Vietnam', N'123', N'User')
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (6, 41, CAST(200.00 AS Decimal(18, 2)), 20, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (7, 36, CAST(200.00 AS Decimal(18, 2)), 20, 2)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (13, 36, CAST(200.00 AS Decimal(18, 2)), 20, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (13, 41, CAST(200.00 AS Decimal(18, 2)), 20, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (14, 36, CAST(200.00 AS Decimal(18, 2)), 60, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (14, 42, CAST(200.00 AS Decimal(18, 2)), 40, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (15, 41, CAST(200.00 AS Decimal(18, 2)), 20, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (16, 41, CAST(200.00 AS Decimal(18, 2)), 12, 1)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (6, 2, CAST(N'2024-10-30T10:14:46.7603443' AS DateTime2), NULL, NULL, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (7, 2, CAST(N'2024-10-30T10:21:57.6125290' AS DateTime2), NULL, NULL, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (13, 2, CAST(N'2024-10-30T10:30:21.9478331' AS DateTime2), NULL, NULL, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (14, 2, CAST(N'2024-10-30T10:34:21.9751484' AS DateTime2), NULL, NULL, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (15, 2, CAST(N'2024-10-30T11:22:33.8963346' AS DateTime2), CAST(N'2024-10-30T11:22:33.8964975' AS DateTime2), CAST(N'2024-11-06T11:22:33.8965673' AS DateTime2), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (16, 2, CAST(N'2024-10-30T11:39:02.3380810' AS DateTime2), CAST(N'2024-10-30T11:39:02.3382449' AS DateTime2), CAST(N'2024-11-06T11:39:02.3383140' AS DateTime2), CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (36, 2, N'Desk', N'12', CAST(200.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (41, 2, N'Table', N'12', CAST(200.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (42, 1, N'Chair', N'12', CAST(200.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (44, 1, N'Lamp', N'12', CAST(210.00 AS Decimal(18, 2)), 20)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 10/30/2024 3:21:00 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_MemberId]    Script Date: 10/30/2024 3:21:00 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_MemberId] ON [dbo].[Orders]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 10/30/2024 3:21:00 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Members_MemberId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [FStoreDB] SET  READ_WRITE 
GO
