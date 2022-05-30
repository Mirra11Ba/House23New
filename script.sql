USE [master]
GO
/****** Object:  Database [House23]    Script Date: 26.05.2022 18:36:40 ******/
CREATE DATABASE [House23]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'House23', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\House23.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'House23_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\House23_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [House23] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [House23].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [House23] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [House23] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [House23] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [House23] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [House23] SET ARITHABORT OFF 
GO
ALTER DATABASE [House23] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [House23] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [House23] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [House23] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [House23] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [House23] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [House23] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [House23] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [House23] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [House23] SET  DISABLE_BROKER 
GO
ALTER DATABASE [House23] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [House23] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [House23] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [House23] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [House23] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [House23] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [House23] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [House23] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [House23] SET  MULTI_USER 
GO
ALTER DATABASE [House23] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [House23] SET DB_CHAINING OFF 
GO
ALTER DATABASE [House23] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [House23] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [House23] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [House23] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [House23] SET QUERY_STORE = OFF
GO
USE [House23]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Patronymic] [nvarchar](20) NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Developer]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Developer](
	[IdDeveloper] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Developer] PRIMARY KEY CLUSTERED 
(
	[IdDeveloper] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[IdDistrict] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[IdDistrict] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Patronymic] [nvarchar](20) NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flat]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flat](
	[IdFlat] [int] IDENTITY(1,1) NOT NULL,
	[BuildingNumberOfRoom] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[NumberOfRooms] [int] NOT NULL,
	[Area] [int] NOT NULL,
	[FloorNumber] [int] NOT NULL,
	[EntranceNumber] [int] NOT NULL,
	[IdSkyscraper] [int] NOT NULL,
	[ImagePreview] [varbinary](max) NULL,
 CONSTRAINT [PK_Flat] PRIMARY KEY CLUSTERED 
(
	[IdFlat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginHistory]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistory](
	[IdLodinHistory] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[IdEmloyee] [int] NOT NULL,
 CONSTRAINT [PK_LoginHistory] PRIMARY KEY CLUSTERED 
(
	[IdLodinHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[IdMaterial] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[IdMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[IdRequest] [int] IDENTITY(1,1) NOT NULL,
	[MinimumPrice] [money] NOT NULL,
	[MaximumPrice] [money] NOT NULL,
	[NumberOfRooms] [int] NOT NULL,
	[MinimumArea] [int] NOT NULL,
	[MaximumArea] [int] NOT NULL,
	[RequestDate] [date] NOT NULL,
	[IdDistrict] [int] NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdRequestStatus] [int] NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestFlat]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestFlat](
	[IdRequest] [int] NOT NULL,
	[IdFlat] [int] NOT NULL,
 CONSTRAINT [PK_RequestFlat] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC,
	[IdFlat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestStatus]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestStatus](
	[IdRequestStatus] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_RequestStatus] PRIMARY KEY CLUSTERED 
(
	[IdRequestStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skyscraper]    Script Date: 26.05.2022 18:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skyscraper](
	[IdSkyscraper] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[NumberOfFloors] [int] NOT NULL,
	[NumberOfEntrances] [int] NOT NULL,
	[NumberOfApartments] [int] NOT NULL,
	[IdDistrict] [int] NOT NULL,
	[IdMaterial] [int] NOT NULL,
	[IdDeveloper] [int] NOT NULL,
 CONSTRAINT [PK_Skyscraper] PRIMARY KEY CLUSTERED 
(
	[IdSkyscraper] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([IdClient], [FirstName], [LastName], [Patronymic], [Phone], [Comment]) VALUES (1, N'Матвей', N'Лакеев', N'Артёмович', N'89189997878', NULL)
INSERT [dbo].[Client] ([IdClient], [FirstName], [LastName], [Patronymic], [Phone], [Comment]) VALUES (2, N'София', N'Дмитрова', N'Алексеевна', N'89182502588', NULL)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Developer] ON 

INSERT [dbo].[Developer] ([IdDeveloper], [Name], [Description]) VALUES (1, N'АСК', N'«АСК» — часть холдинга AVA Group. AVA Group — девелопер федерального уровня, в портфеле компании 115 сданных объектов общей площадью более 1 280 000 кв.м.')
INSERT [dbo].[Developer] ([IdDeveloper], [Name], [Description]) VALUES (2, N'ЮгСтройИмпериал', N'Строительная компания')
INSERT [dbo].[Developer] ([IdDeveloper], [Name], [Description]) VALUES (3, N'Девелопмент-Юг', N'Сегодня корпорацией реализуются проекты в восьми городах - Краснодаре, Перми, Ростове-на-Дону, Батайске, Астрахани, Владивостоке, Нижнем Новгороде и Екатеринбурге. Особое внимание уделяется качеству жилья и формированию комфортной среды для жизни.')
SET IDENTITY_INSERT [dbo].[Developer] OFF
GO
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([IdDistrict], [Name]) VALUES (1, N'ЧМР')
INSERT [dbo].[District] ([IdDistrict], [Name]) VALUES (2, N'ЦМР')
INSERT [dbo].[District] ([IdDistrict], [Name]) VALUES (3, N'ФМР')
INSERT [dbo].[District] ([IdDistrict], [Name]) VALUES (4, N'ЮМР')
INSERT [dbo].[District] ([IdDistrict], [Name]) VALUES (5, N'ГМР')
SET IDENTITY_INSERT [dbo].[District] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([IdEmployee], [FirstName], [LastName], [Patronymic], [Phone], [Login], [Password], [IdRole]) VALUES (2, N'Александр', N'Богданов', N'Даниилович', N'89189693142', N'rel1', N'rel1', 2)
INSERT [dbo].[Employee] ([IdEmployee], [FirstName], [LastName], [Patronymic], [Phone], [Login], [Password], [IdRole]) VALUES (5, N'Василиса', N'Беликова', N'Кирилловна', N'89189917578', N'rel2', N'rel2', 2)
INSERT [dbo].[Employee] ([IdEmployee], [FirstName], [LastName], [Patronymic], [Phone], [Login], [Password], [IdRole]) VALUES (7, N'Дмитрий', N'Гордеев', N'Владиславович', N'89605553754', N'hrm1', N'hrm1', 1)
INSERT [dbo].[Employee] ([IdEmployee], [FirstName], [LastName], [Patronymic], [Phone], [Login], [Password], [IdRole]) VALUES (9, N'Елена', N'Бонго', N'Сергеевна', N'89189994455', N'rel3', N'rel3', 2)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Flat] ON 

INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (1, 100, 4000000.0000, 1, 32, 8, 1, 1, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (2, 179, 5500000.0000, 2, 60, 10, 4, 2, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (5, 189, 7500000.0000, 3, 90, 17, 3, 4, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (6, 200, 11000000.0000, 3, 100, 12, 2, 1, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (7, 41, 8500000.0000, 3, 75, 11, 5, 5, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (8, 25, 9500000.0000, 3, 80, 3, 2, 5, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (9, 90, 9000000.0000, 3, 79, 27, 4, 2, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (10, 52, 4500000.0000, 2, 50, 5, 1, 7, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (11, 30, 5200000.0000, 2, 55, 4, 4, 7, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (13, 24, 5000000.0000, 2, 50, 8, 3, 4, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (14, 64, 4900000.0000, 2, 49, 15, 1, 4, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (15, 195, 4500000.0000, 1, 31, 9, 4, 1, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (17, 102, 4700000.0000, 1, 42, 7, 2, 5, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (18, 111, 4800000.0000, 1, 45, 16, 3, 4, NULL)
INSERT [dbo].[Flat] ([IdFlat], [BuildingNumberOfRoom], [Price], [NumberOfRooms], [Area], [FloorNumber], [EntranceNumber], [IdSkyscraper], [ImagePreview]) VALUES (20, 72, 4400000.0000, 1, 37, 20, 1, 2, NULL)
SET IDENTITY_INSERT [dbo].[Flat] OFF
GO
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([IdMaterial], [Name]) VALUES (1, N'Кирпич')
INSERT [dbo].[Material] ([IdMaterial], [Name]) VALUES (2, N'Монолит')
INSERT [dbo].[Material] ([IdMaterial], [Name]) VALUES (3, N'Монолит-кирпич')
INSERT [dbo].[Material] ([IdMaterial], [Name]) VALUES (4, N'Панель')
SET IDENTITY_INSERT [dbo].[Material] OFF
GO
SET IDENTITY_INSERT [dbo].[Request] ON 

INSERT [dbo].[Request] ([IdRequest], [MinimumPrice], [MaximumPrice], [NumberOfRooms], [MinimumArea], [MaximumArea], [RequestDate], [IdDistrict], [IdEmployee], [IdClient], [IdRequestStatus]) VALUES (2, 4100000.0000, 4700000.0000, 1, 31, 43, CAST(N'2022-05-21' AS Date), 1, 2, 1, 2)
SET IDENTITY_INSERT [dbo].[Request] OFF
GO
INSERT [dbo].[RequestFlat] ([IdRequest], [IdFlat]) VALUES (2, 15)
INSERT [dbo].[RequestFlat] ([IdRequest], [IdFlat]) VALUES (2, 17)
GO
SET IDENTITY_INSERT [dbo].[RequestStatus] ON 

INSERT [dbo].[RequestStatus] ([IdRequestStatus], [Status]) VALUES (1, N'Выполнена')
INSERT [dbo].[RequestStatus] ([IdRequestStatus], [Status]) VALUES (2, N'Обрабатывается')
INSERT [dbo].[RequestStatus] ([IdRequestStatus], [Status]) VALUES (3, N'Не выполнена')
SET IDENTITY_INSERT [dbo].[RequestStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [Name], [Description]) VALUES (1, N'Кадровик', N'Сотрудник, котрый регисрирует риелтора в системе.')
INSERT [dbo].[Role] ([IdRole], [Name], [Description]) VALUES (2, N'Риелтор', N'Сотрудник, котрый работает с клиентом, застройщиками, объектами недвижимости.')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Skyscraper] ON 

INSERT [dbo].[Skyscraper] ([IdSkyscraper], [Name], [Address], [NumberOfFloors], [NumberOfEntrances], [NumberOfApartments], [IdDistrict], [IdMaterial], [IdDeveloper]) VALUES (1, N'ЖК Достоевский', N'ул Мира 30', 21, 5, 200, 1, 3, 3)
INSERT [dbo].[Skyscraper] ([IdSkyscraper], [Name], [Address], [NumberOfFloors], [NumberOfEntrances], [NumberOfApartments], [IdDistrict], [IdMaterial], [IdDeveloper]) VALUES (2, N'ЖК Тургенев', N'ул Озерная 15', 30, 7, 250, 2, 1, 1)
INSERT [dbo].[Skyscraper] ([IdSkyscraper], [Name], [Address], [NumberOfFloors], [NumberOfEntrances], [NumberOfApartments], [IdDistrict], [IdMaterial], [IdDeveloper]) VALUES (4, N'ЖК Большой', N'ул Красная 72', 25, 5, 220, 2, 2, 2)
INSERT [dbo].[Skyscraper] ([IdSkyscraper], [Name], [Address], [NumberOfFloors], [NumberOfEntrances], [NumberOfApartments], [IdDistrict], [IdMaterial], [IdDeveloper]) VALUES (5, N'ЖК Элегант', N'ул Старокубанская 131', 25, 5, 230, 4, 4, 1)
INSERT [dbo].[Skyscraper] ([IdSkyscraper], [Name], [Address], [NumberOfFloors], [NumberOfEntrances], [NumberOfApartments], [IdDistrict], [IdMaterial], [IdDeveloper]) VALUES (7, N'ЖК Фамилия', N'ул Старокубанская 124', 30, 7, 240, 3, 3, 3)
SET IDENTITY_INSERT [dbo].[Skyscraper] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Flat]  WITH CHECK ADD  CONSTRAINT [FK_Flat_Skyscraper] FOREIGN KEY([IdSkyscraper])
REFERENCES [dbo].[Skyscraper] ([IdSkyscraper])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flat] CHECK CONSTRAINT [FK_Flat_Skyscraper]
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistory_Employee] FOREIGN KEY([IdEmloyee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[LoginHistory] CHECK CONSTRAINT [FK_LoginHistory_Employee]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Client]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_District] FOREIGN KEY([IdDistrict])
REFERENCES [dbo].[District] ([IdDistrict])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_District]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Employee1] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Employee1]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_RequestStatus] FOREIGN KEY([IdRequestStatus])
REFERENCES [dbo].[RequestStatus] ([IdRequestStatus])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_RequestStatus]
GO
ALTER TABLE [dbo].[RequestFlat]  WITH CHECK ADD  CONSTRAINT [FK_RequestFlat_Flat] FOREIGN KEY([IdFlat])
REFERENCES [dbo].[Flat] ([IdFlat])
GO
ALTER TABLE [dbo].[RequestFlat] CHECK CONSTRAINT [FK_RequestFlat_Flat]
GO
ALTER TABLE [dbo].[RequestFlat]  WITH CHECK ADD  CONSTRAINT [FK_RequestFlat_Request] FOREIGN KEY([IdRequest])
REFERENCES [dbo].[Request] ([IdRequest])
GO
ALTER TABLE [dbo].[RequestFlat] CHECK CONSTRAINT [FK_RequestFlat_Request]
GO
ALTER TABLE [dbo].[Skyscraper]  WITH CHECK ADD  CONSTRAINT [FK_Skyscraper_Developer] FOREIGN KEY([IdDeveloper])
REFERENCES [dbo].[Developer] ([IdDeveloper])
GO
ALTER TABLE [dbo].[Skyscraper] CHECK CONSTRAINT [FK_Skyscraper_Developer]
GO
ALTER TABLE [dbo].[Skyscraper]  WITH CHECK ADD  CONSTRAINT [FK_Skyscraper_District] FOREIGN KEY([IdDistrict])
REFERENCES [dbo].[District] ([IdDistrict])
GO
ALTER TABLE [dbo].[Skyscraper] CHECK CONSTRAINT [FK_Skyscraper_District]
GO
ALTER TABLE [dbo].[Skyscraper]  WITH CHECK ADD  CONSTRAINT [FK_Skyscraper_Material] FOREIGN KEY([IdMaterial])
REFERENCES [dbo].[Material] ([IdMaterial])
GO
ALTER TABLE [dbo].[Skyscraper] CHECK CONSTRAINT [FK_Skyscraper_Material]
GO
USE [master]
GO
ALTER DATABASE [House23] SET  READ_WRITE 
GO
