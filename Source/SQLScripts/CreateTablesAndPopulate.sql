USE [rewards]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Email] [nvarchar](128) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AccountCode] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[FirstAddress] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Enrrolled] [int] NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[MobileNumber] [nvarchar](max) NULL,
	[FaxNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[ItemName] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'cecil@workingdata.au', 4, N'AC761459', N'Jessie', N'Burton', N'385 Akuehe Trail', N'Hobart', N'Australia', N'038278', N'http://workingdata.com', 1, 1, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'christina@workingdata.com', 9, N'AC122458', N'Christina', N'Meyer', N'512 Tadta Pass', N'New York', N'United States', N'038278', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'darrell@workingdata.com', 6, N'AC174967', N'Darrell', N'Russell', N'1155 NE 8th St', N'Florida', N'United States', N'108278', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'elijah@workingdata.com', 8, N'AC783452', N'Elijah', N'Rodriquez', N'1076 Viero Key', N'Rio de Janeiro', N'Brazil', N'038278', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'john@workingdata.co.uk', 1, N'AC234323', N'John', N'Doe', N'562 Mokice View', N'Dundee', N'United Kingdom', N'188930', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'maria@workingdata.com', 7, N'AC714897', N'Maria', N'Gordon', N'882 Emevo Key', N'Sevilla', N'Spain', N'54864', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'olivia@workingdata.com', 10, N'AC458752', N'Olivia', N'Cohen', N'1916 Pinut Drive', N'Toronto', N'Canada', N'458756', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'sophie@workingdata.com', 2, N'AC234148', N'Sophie', N'Stevenson', N'1018 Obevir Extension', N'Chicago', N'United States', N'184342', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'steven@workingdata.mx', 5, N'AC741655', N'Steven', N'Martin', N'1646 Oriro Loop', N'Monterrey', N'Mexico', N'154715', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
INSERT [dbo].[Customers] ([Email], [CustomerId], [AccountCode], [FirstName], [LastName], [FirstAddress], [City], [Country], [ZipCode], [Website], [Active], [Enrrolled], [PhoneNumber], [MobileNumber], [FaxNumber]) VALUES (N'trevor@workingdata.com', 3, N'AC451745', N'Trevor', N'Adkins', N'1508 Hepik Junction', N'Toronto', N'Canada', N'44118', N'http://workingdata.com', 1, 0, N'4251231234', N'4253214321', N'4259990000')
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (1, N'192384529', CAST(N'2019-06-09T09:53:32.580' AS DateTime), N'Retail', N'Hammer', N'Placed', CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (2, N'18903849', CAST(N'2019-06-11T09:53:32.580' AS DateTime), N'Web', N'Wrench', N'--', CAST(150.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (3, N'18983945', CAST(N'2019-06-10T09:53:32.580' AS DateTime), N'Phone', N'Cordless Drill', N'--', CAST(225.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (4, N'18983990', CAST(N'2019-06-09T09:53:32.580' AS DateTime), N'Web', N'Hammer', N'--', CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (5, N'18983990', CAST(N'2019-06-08T09:53:32.580' AS DateTime), N'Retail', N'Drill', N'--', CAST(225.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (6, N'142184222', CAST(N'2019-06-05T09:53:32.580' AS DateTime), N'Sheds', N'Storage Shed Coated Steel', N'placed', CAST(500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (7, N'142184923', CAST(N'2019-06-02T09:53:32.580' AS DateTime), N'Sheds', N'Outdoor Storage Shed Steel', N'--', CAST(150.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (8, N'18983213', CAST(N'2019-06-06T09:53:32.580' AS DateTime), N'Heating', N'Stove', N'Placed', CAST(220.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (9, N'189832562', CAST(N'2019-06-09T09:53:32.580' AS DateTime), N'Heating', N'Propane Wall Heater', N'--', CAST(320.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (10, N'18988730', CAST(N'2019-05-28T09:53:32.580' AS DateTime), N'Security', N'Outdoor Security Camera', N'Placed', CAST(115.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [Code], [Date], [Type], [ItemName], [Status], [Total]) VALUES (11, N'18676990', CAST(N'2019-05-18T09:53:32.580' AS DateTime), N'Security', N'Plug-in Indoor Camera', N'Placed', CAST(75.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
