USE [TestDB]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 18/03/2024 12:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Brand] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSearchHistory]    Script Date: 18/03/2024 12:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSearchHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SearchKey] [nvarchar](100) NULL,
	[SearchByUserId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_ProductSearchHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 18/03/2024 12:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](500) NULL,
	[Role] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Quantity], [Brand], [IsActive]) VALUES (1, N'TV', N'LED TV', CAST(1000.00 AS Decimal(18, 2)), 10, N'SONEY', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Quantity], [Brand], [IsActive]) VALUES (2, N'Laptop', N'Intel Laptop', CAST(1500.00 AS Decimal(18, 2)), 15, N'Lenovo', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Quantity], [Brand], [IsActive]) VALUES (3, N'TV', N'LED', CAST(1500.00 AS Decimal(18, 2)), 15, N'Philips', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Quantity], [Brand], [IsActive]) VALUES (4, N'Phone', N'Smart Phone', CAST(500.00 AS Decimal(18, 2)), 25, N'MI', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Quantity], [Brand], [IsActive]) VALUES (5, N'Phone', N'Smart Phone', CAST(800.00 AS Decimal(18, 2)), 25, N'Nokia', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Quantity], [Brand], [IsActive]) VALUES (6, N'Phone', N'Smart Phone', CAST(1000.00 AS Decimal(18, 2)), 25, N'SamSung', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Quantity], [Brand], [IsActive]) VALUES (7, N'Phone', N'Smart Phone', CAST(1000.00 AS Decimal(18, 2)), 25, N'SamSung', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSearchHistory] ON 

INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (1, N'Laptop', 1, 1, CAST(N'2024-03-16T22:19:43.483' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (2, N'TV', 1, 1, CAST(N'2024-03-16T22:20:11.550' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (3, N'TV', 1, 1, CAST(N'2024-03-16T23:25:40.063' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (4, N'TV', 1, 1, CAST(N'2024-03-17T16:56:44.880' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (5, N'1233', 1, 1, CAST(N'2024-03-17T16:57:41.277' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (6, N'1233', 1, 1, CAST(N'2024-03-17T17:21:28.507' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (7, N'Mobile', 1, 1, CAST(N'2024-03-17T17:21:41.363' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (8, N'TV', 1, 1, CAST(N'2024-03-17T17:21:48.013' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (9, N'TV', 1, 1, CAST(N'2024-03-17T17:22:37.117' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (10, N'TV', 1, 1, CAST(N'2024-03-17T17:53:28.303' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (11, N'TV', 1, 1, CAST(N'2024-03-17T17:55:07.980' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (12, N'TV', 1, 1, CAST(N'2024-03-17T17:58:37.993' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (13, N'TV', 1, 1, CAST(N'2024-03-17T18:01:23.940' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (14, N'TV', 1, 1, CAST(N'2024-03-17T18:06:54.277' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (15, N'TV', 1, 1, CAST(N'2024-03-17T18:08:58.293' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (16, N'TV', 1, 1, CAST(N'2024-03-17T18:12:17.847' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (17, N'TV', 1, 1, CAST(N'2024-03-17T18:14:33.203' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (18, N'TV', 1, 1, CAST(N'2024-03-17T18:15:55.583' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (19, N'TV', 1, 1, CAST(N'2024-03-17T18:17:52.773' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (20, N'TV', 1, 1, CAST(N'2024-03-17T18:33:02.857' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (21, N'TV', 1, 1, CAST(N'2024-03-17T18:33:20.147' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (22, N'TV', 1, 1, CAST(N'2024-03-17T18:35:02.843' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (23, N'TV', 1, 1, CAST(N'2024-03-17T18:50:20.957' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (24, N'TV', 1, 1, CAST(N'2024-03-17T22:18:52.327' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (25, N'TV', 1, 1, CAST(N'2024-03-17T22:18:58.247' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (26, N'TV', 1, 1, CAST(N'2024-03-17T22:19:01.403' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (27, N'TV', 1, 1, CAST(N'2024-03-17T22:19:16.143' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (28, N'TV', 1, 1, CAST(N'2024-03-17T22:20:01.300' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (29, N'TV', 1, 1, CAST(N'2024-03-17T22:22:05.387' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (30, N'TV', 1, 1, CAST(N'2024-03-17T22:22:35.367' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (31, N'TV', 1, 1, CAST(N'2024-03-17T22:22:43.763' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (32, N'TV', 1, 1, CAST(N'2024-03-17T22:23:24.417' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (33, N'TV', 1, 1, CAST(N'2024-03-17T22:23:50.007' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (34, N'TV', 1, 1, CAST(N'2024-03-17T22:24:04.957' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (35, N'TV', 1, 1, CAST(N'2024-03-17T23:21:24.240' AS DateTime))
INSERT [dbo].[ProductSearchHistory] ([Id], [SearchKey], [SearchByUserId], [IsActive], [CreatedDate]) VALUES (36, N'w', 1, 1, CAST(N'2024-03-17T23:22:22.490' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductSearchHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

INSERT [dbo].[UserMaster] ([Id], [UserName], [Email], [Password], [Role], [IsActive], [CreatedDate]) VALUES (1, N'test', N'test@gmail.com', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f', N'Admin', NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [UserName], [Email], [Password], [Role], [IsActive], [CreatedDate]) VALUES (2, N'test1', N'test1@gmail.com', N'1b4f0e9851971998e732078544c96b36c3d01cedf7caa332359d6f1d83567014', N'Admin', 1, CAST(N'2024-03-17T22:53:05.530' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
GO
