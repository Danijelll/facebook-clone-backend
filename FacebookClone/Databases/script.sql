USE [master]
GO
/****** Object:  Database [FacebookCloneDB]    Script Date: 5/12/2022 4:45:54 PM ******/
CREATE DATABASE [FacebookCloneDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FacebookCloneDB', FILENAME = N'D:\Software\SqlServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\FacebookCloneDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FacebookCloneDB_log', FILENAME = N'D:\Software\SqlServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\FacebookCloneDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FacebookCloneDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FacebookCloneDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FacebookCloneDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FacebookCloneDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FacebookCloneDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FacebookCloneDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FacebookCloneDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET RECOVERY FULL 
GO
ALTER DATABASE [FacebookCloneDB] SET  MULTI_USER 
GO
ALTER DATABASE [FacebookCloneDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FacebookCloneDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FacebookCloneDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FacebookCloneDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FacebookCloneDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FacebookCloneDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FacebookCloneDB', N'ON'
GO
ALTER DATABASE [FacebookCloneDB] SET QUERY_STORE = OFF
GO
USE [FacebookCloneDB]
GO
/****** Object:  Table [dbo].[album]    Script Date: 5/12/2022 4:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[caption] [varchar](50) NOT NULL,
	[created_on] [datetime] NOT NULL,
	[updated_on] [datetime] NOT NULL,
 CONSTRAINT [PK_album] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 5/12/2022 4:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[album_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[text] [varchar](120) NOT NULL,
	[created_on] [datetime] NOT NULL,
	[updated_on] [datetime] NOT NULL,
 CONSTRAINT [PK_comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[email_confirm]    Script Date: 5/12/2022 4:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[email_confirm](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[email_hash] [varchar](60) NOT NULL,
	[created_on] [datetime] NOT NULL,
	[updated_on] [datetime] NOT NULL,
 CONSTRAINT [PK_email_confirm] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[friend_request]    Script Date: 5/12/2022 4:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[friend_request](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_user_id] [int] NOT NULL,
	[second_user_id] [int] NOT NULL,
	[is_accepted] [bit] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[updated_on] [datetime] NOT NULL,
 CONSTRAINT [PK_friend_request] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[image]    Script Date: 5/12/2022 4:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[album_id] [int] NOT NULL,
	[image_url] [varchar](120) NOT NULL,
	[created_on] [datetime] NOT NULL,
	[updated_on] [datetime] NOT NULL,
 CONSTRAINT [PK_image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[two_factor_authentication]    Script Date: 5/12/2022 4:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[two_factor_authentication](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_email] [varchar](120) NOT NULL,
	[two_factor_code] [varchar](14) NOT NULL,
	[created_on] [datetime] NOT NULL,
	[updated_on] [datetime] NOT NULL,
 CONSTRAINT [PK_two_factor_authentication] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 5/12/2022 4:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] NOT NULL,
	[username] [varchar](30) NOT NULL,
	[email] [varchar](70) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[role] [int] NOT NULL,
	[is_banned] [bit] NOT NULL,
	[is_email_confirmed] [bit] NOT NULL,
	[profile_image] [varchar](120) NOT NULL,
	[cover_image] [varchar](120) NOT NULL,
	[created_on] [datetime] NOT NULL,
	[updated_on] [datetime] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[album] ON 

INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (8, 1, N'', CAST(N'2022-04-15T12:42:13.260' AS DateTime), CAST(N'2022-04-15T12:42:13.260' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (9, 1, N'', CAST(N'2022-04-15T12:43:03.573' AS DateTime), CAST(N'2022-04-15T12:43:03.573' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (10, 1, N'', CAST(N'2022-04-15T12:43:06.387' AS DateTime), CAST(N'2022-04-15T12:43:06.387' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (11, 1, N'', CAST(N'2022-04-15T13:08:53.657' AS DateTime), CAST(N'2022-04-15T13:08:53.657' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (12, 1, N'', CAST(N'2022-04-15T13:09:35.683' AS DateTime), CAST(N'2022-04-15T13:09:35.683' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (13, 1, N'', CAST(N'2022-04-15T13:12:00.863' AS DateTime), CAST(N'2022-04-15T13:12:00.863' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (14, 1, N'', CAST(N'2022-04-15T13:13:05.597' AS DateTime), CAST(N'2022-04-15T13:13:05.597' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (15, 1, N'', CAST(N'2022-04-15T13:22:36.047' AS DateTime), CAST(N'2022-04-15T13:22:36.047' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (16, 1, N'', CAST(N'2022-04-15T14:02:27.730' AS DateTime), CAST(N'2022-04-15T14:02:27.730' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (20, 14, N'kkk', CAST(N'2022-04-15T14:16:38.993' AS DateTime), CAST(N'2022-04-15T14:16:38.993' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (21, 44, N'asdasdads', CAST(N'2022-04-19T07:37:07.990' AS DateTime), CAST(N'2022-05-05T14:32:06.710' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (1021, 44, N'kkkkkkkkkkkkkkkkk', CAST(N'2022-04-19T12:37:37.477' AS DateTime), CAST(N'2022-04-19T12:37:37.477' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (1022, 44, N'AAAA', CAST(N'2022-04-20T08:42:00.010' AS DateTime), CAST(N'2022-04-20T08:42:00.010' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (1023, 1, N'', CAST(N'2022-05-04T09:49:52.307' AS DateTime), CAST(N'2022-05-04T09:49:52.307' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (1024, 44, N'', CAST(N'2022-05-04T12:50:48.647' AS DateTime), CAST(N'2022-05-04T12:50:48.647' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2024, 44, N'Bruh Moment', CAST(N'2022-05-05T09:47:04.693' AS DateTime), CAST(N'2022-05-05T09:47:04.693' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2030, 29, N'', CAST(N'2022-05-10T11:48:46.987' AS DateTime), CAST(N'2022-05-10T11:48:46.987' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2031, 29, N'', CAST(N'2022-05-10T12:15:39.390' AS DateTime), CAST(N'2022-05-10T12:15:39.390' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2032, 29, N'', CAST(N'2022-05-10T12:15:47.737' AS DateTime), CAST(N'2022-05-10T12:15:47.737' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2033, 37, N'', CAST(N'2022-05-10T12:16:44.690' AS DateTime), CAST(N'2022-05-10T12:16:44.690' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2034, 37, N'', CAST(N'2022-05-10T12:16:52.580' AS DateTime), CAST(N'2022-05-10T12:16:52.580' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2035, 37, N'', CAST(N'2022-05-10T12:16:56.347' AS DateTime), CAST(N'2022-05-10T12:16:56.347' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2036, 38, N'', CAST(N'2022-05-10T12:18:02.137' AS DateTime), CAST(N'2022-05-10T12:18:02.137' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2037, 38, N'', CAST(N'2022-05-10T12:18:06.080' AS DateTime), CAST(N'2022-05-10T12:18:06.080' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2038, 38, N'', CAST(N'2022-05-10T12:18:12.607' AS DateTime), CAST(N'2022-05-10T12:18:12.607' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2039, 38, N'', CAST(N'2022-05-10T12:18:18.283' AS DateTime), CAST(N'2022-05-10T12:18:18.283' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2040, 38, N'', CAST(N'2022-05-10T12:18:25.470' AS DateTime), CAST(N'2022-05-10T12:18:25.470' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2041, 32, N'', CAST(N'2022-05-10T12:21:53.740' AS DateTime), CAST(N'2022-05-10T12:21:53.740' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2042, 32, N'', CAST(N'2022-05-10T12:22:05.593' AS DateTime), CAST(N'2022-05-10T12:22:05.593' AS DateTime))
INSERT [dbo].[album] ([id], [user_id], [caption], [created_on], [updated_on]) VALUES (2043, 1043, N'HEHEEHHEEHE MATA', CAST(N'2022-05-11T11:20:15.617' AS DateTime), CAST(N'2022-05-11T11:20:15.617' AS DateTime))
SET IDENTITY_INSERT [dbo].[album] OFF
GO
SET IDENTITY_INSERT [dbo].[comment] ON 

INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (4, 21, 17, N'hehehe ha', CAST(N'2022-04-27T13:41:48.740' AS DateTime), CAST(N'2022-04-27T13:41:48.740' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (5, 21, 17, N'hehehe ha', CAST(N'2022-04-27T13:41:55.530' AS DateTime), CAST(N'2022-04-27T13:41:55.530' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (6, 21, 17, N'hehehe ha2', CAST(N'2022-04-27T13:42:00.937' AS DateTime), CAST(N'2022-04-27T13:42:00.937' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (7, 21, 17, N'hehehe ha2', CAST(N'2022-04-28T11:53:14.453' AS DateTime), CAST(N'2022-04-28T11:53:14.453' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (8, 21, 17, N'hehehe ha2', CAST(N'2022-04-28T11:53:21.060' AS DateTime), CAST(N'2022-04-28T11:53:21.060' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (12, 1022, 44, N'AAAAAAAAAAAAAAAA', CAST(N'2022-04-28T12:37:43.227' AS DateTime), CAST(N'2022-04-28T12:37:43.227' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (13, 1022, 44, N'aaaaaaaa', CAST(N'2022-04-28T12:40:26.297' AS DateTime), CAST(N'2022-04-28T12:40:26.297' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (14, 21, 44, N'help', CAST(N'2022-04-28T12:43:50.393' AS DateTime), CAST(N'2022-04-28T12:43:50.393' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (15, 21, 44, N'asdasdasd', CAST(N'2022-04-28T12:46:07.970' AS DateTime), CAST(N'2022-04-28T12:46:07.970' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (16, 21, 44, N'sdaadsdasasd', CAST(N'2022-04-28T12:48:56.277' AS DateTime), CAST(N'2022-05-09T09:44:06.170' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (21, 1022, 44, N'1st', CAST(N'2022-04-28T12:54:35.870' AS DateTime), CAST(N'2022-04-28T12:54:35.870' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (22, 1022, 44, N'2nd', CAST(N'2022-04-28T12:54:43.913' AS DateTime), CAST(N'2022-04-28T12:54:43.913' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (23, 1022, 44, N'3rd', CAST(N'2022-04-28T12:54:50.623' AS DateTime), CAST(N'2022-04-28T12:54:50.623' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (24, 1022, 44, N'asdasdasdasdasd', CAST(N'2022-04-28T12:55:08.433' AS DateTime), CAST(N'2022-04-28T12:55:08.433' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (25, 1022, 44, N'asd', CAST(N'2022-04-28T12:56:53.897' AS DateTime), CAST(N'2022-04-28T12:56:53.897' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (26, 1022, 44, N'asd', CAST(N'2022-04-28T12:57:08.933' AS DateTime), CAST(N'2022-04-28T12:57:08.933' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (27, 1022, 44, N'image 3', CAST(N'2022-04-28T13:05:24.850' AS DateTime), CAST(N'2022-04-28T13:05:24.850' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (28, 1022, 44, N'img3', CAST(N'2022-04-28T13:05:36.573' AS DateTime), CAST(N'2022-04-28T13:05:36.573' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (29, 1022, 44, N'last image 3', CAST(N'2022-04-28T13:12:33.667' AS DateTime), CAST(N'2022-04-28T13:12:33.667' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (30, 1021, 44, N'image 2', CAST(N'2022-04-28T13:24:51.287' AS DateTime), CAST(N'2022-04-28T13:24:51.287' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (31, 1021, 44, N'img2', CAST(N'2022-04-28T13:24:55.727' AS DateTime), CAST(N'2022-04-28T13:24:55.727' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (32, 1021, 44, N'img2', CAST(N'2022-04-28T13:24:55.990' AS DateTime), CAST(N'2022-04-28T13:24:55.990' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (33, 1021, 44, N'img2', CAST(N'2022-04-28T13:24:56.117' AS DateTime), CAST(N'2022-04-28T13:24:56.117' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (34, 1021, 44, N'img2 last', CAST(N'2022-04-28T13:25:00.900' AS DateTime), CAST(N'2022-04-28T13:25:00.900' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (35, 1021, 44, N'second img', CAST(N'2022-04-28T14:25:44.233' AS DateTime), CAST(N'2022-04-28T14:25:44.233' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (37, 1021, 44, N'', CAST(N'2022-04-28T14:29:02.823' AS DateTime), CAST(N'2022-04-28T14:29:02.823' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (46, 21, 17, N'?? postman 1st album aaaaaaaaaaaa', CAST(N'2022-04-29T09:15:27.040' AS DateTime), CAST(N'2022-04-29T09:15:27.040' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (50, 1022, 44, N'aaa', CAST(N'2022-04-29T10:12:54.270' AS DateTime), CAST(N'2022-04-29T10:12:54.270' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (51, 1022, 44, N'heheheh', CAST(N'2022-04-29T10:12:58.033' AS DateTime), CAST(N'2022-04-29T10:12:58.033' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (53, 21, 44, N'aaaaaa', CAST(N'2022-04-29T10:14:46.333' AS DateTime), CAST(N'2022-05-12T08:11:06.387' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (54, 21, 44, N'asd', CAST(N'2022-04-29T10:14:48.737' AS DateTime), CAST(N'2022-04-29T10:14:48.737' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (58, 21, 44, N'aaaaaaaaaaa', CAST(N'2022-04-29T10:15:41.150' AS DateTime), CAST(N'2022-05-06T09:52:39.950' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (59, 21, 44, N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', CAST(N'2022-04-29T10:15:43.490' AS DateTime), CAST(N'2022-05-06T09:18:25.183' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (87, 2024, 44, N'', CAST(N'2022-05-06T08:00:45.093' AS DateTime), CAST(N'2022-05-06T08:00:45.093' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (89, 2042, 44, N'asd', CAST(N'2022-05-11T09:09:44.937' AS DateTime), CAST(N'2022-05-11T09:09:44.937' AS DateTime))
INSERT [dbo].[comment] ([id], [album_id], [user_id], [text], [created_on], [updated_on]) VALUES (90, 2042, 32, N'asdasdasdasd', CAST(N'2022-05-11T13:39:12.573' AS DateTime), CAST(N'2022-05-11T13:39:12.573' AS DateTime))
SET IDENTITY_INSERT [dbo].[comment] OFF
GO
SET IDENTITY_INSERT [dbo].[email_confirm] ON 

INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (1, 19, N'$2a$11$3yYJxFv7OrqLU6RnYFJnxuRFlGhKVOEgxnFdRkFCgEaQWw9Xva/E2', CAST(N'2022-04-06T13:06:27.803' AS DateTime), CAST(N'2022-04-06T13:06:27.803' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (2, 20, N'$2a$11$peR.Sh6FwKX4JIanOc4XLOx4ffzqgpQKdX9KsPWp7EsE74r3IlIjm', CAST(N'2022-04-06T13:56:27.317' AS DateTime), CAST(N'2022-04-06T13:56:27.317' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (3, 21, N'$2a$11$820.2Co6J8dEBTmGDKMZUeYcmRt22ory241AONxRnJ3nDUg7vcLxO', CAST(N'2022-04-06T13:59:53.310' AS DateTime), CAST(N'2022-04-06T13:59:53.310' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (6, 24, N'$2a$11$ezY4wXeABK/K.xr.xQOvZOrYaRlD7/x/OZc48Iwj4vI6auyb3XOM2', CAST(N'2022-04-07T10:52:05.577' AS DateTime), CAST(N'2022-04-07T10:52:05.577' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (8, 26, N'$2a$11$fZ3dbiFo3XTVAtgD5MLoaOpnc4v/vws8VMWbqG.4jR7HFckxkDSue', CAST(N'2022-04-07T10:58:08.973' AS DateTime), CAST(N'2022-04-07T10:58:08.973' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (16, 34, N'$2a$11$0Y1kzI3.LLjgWRY9e6idze5sv1WC7hjtMAsly1AYXWe-P5arYecOe', CAST(N'2022-04-13T09:48:15.497' AS DateTime), CAST(N'2022-04-13T09:48:15.497' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (17, 35, N'$2a$11$14UJsZrn7i3dJPhIbWVzo.b7xsbrFYrJXE6B5cIorWTOc1lmqcev6', CAST(N'2022-04-13T09:53:30.420' AS DateTime), CAST(N'2022-04-13T09:53:30.420' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (18, 36, N'$2a$11$veWRJBR6-XWn0W0KcpheYeMkmqITpn.EZAFY0A3D43Pdryt20MRh.', CAST(N'2022-04-13T11:48:45.443' AS DateTime), CAST(N'2022-04-13T11:48:45.443' AS DateTime))
INSERT [dbo].[email_confirm] ([id], [user_id], [email_hash], [created_on], [updated_on]) VALUES (21, 43, N'$2a$11$wpaXO..t72PsXD1reqoOZucE-MN.LsUH3Z6L1JUaif9s0wYJy15zi', CAST(N'2022-04-18T07:51:21.343' AS DateTime), CAST(N'2022-04-18T07:51:21.343' AS DateTime))
SET IDENTITY_INSERT [dbo].[email_confirm] OFF
GO
SET IDENTITY_INSERT [dbo].[friend_request] ON 

INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (182, 29, 44, 1, CAST(N'2022-05-10T08:58:50.183' AS DateTime), CAST(N'2022-05-10T08:59:10.477' AS DateTime))
INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (183, 38, 44, 1, CAST(N'2022-05-10T09:27:16.367' AS DateTime), CAST(N'2022-05-10T12:16:10.220' AS DateTime))
INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (184, 37, 44, 1, CAST(N'2022-05-10T09:28:13.907' AS DateTime), CAST(N'2022-05-10T12:16:15.680' AS DateTime))
INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (185, 38, 32, 0, CAST(N'2022-05-10T12:21:36.283' AS DateTime), CAST(N'2022-05-10T12:21:36.283' AS DateTime))
INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (186, 32, 44, 1, CAST(N'2022-05-10T12:22:17.773' AS DateTime), CAST(N'2022-05-10T12:22:37.870' AS DateTime))
INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (187, 44, 1, 1, CAST(N'2022-05-10T12:52:17.923' AS DateTime), CAST(N'2022-05-10T12:52:17.923' AS DateTime))
INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (188, 44, 14, 1, CAST(N'2022-05-10T12:52:21.397' AS DateTime), CAST(N'2022-05-10T12:52:21.397' AS DateTime))
INSERT [dbo].[friend_request] ([id], [first_user_id], [second_user_id], [is_accepted], [created_on], [updated_on]) VALUES (189, 1043, 44, 1, CAST(N'2022-05-11T11:19:58.477' AS DateTime), CAST(N'2022-05-11T11:20:31.313' AS DateTime))
SET IDENTITY_INSERT [dbo].[friend_request] OFF
GO
SET IDENTITY_INSERT [dbo].[image] ON 

INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (15, 8, N'6378562333323390791189845395.jpg', CAST(N'2022-04-15T12:42:13.540' AS DateTime), CAST(N'2022-04-15T12:42:13.540' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (16, 8, N'637856233332373168302484584.jpg', CAST(N'2022-04-15T12:42:13.590' AS DateTime), CAST(N'2022-04-15T12:42:13.590' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (17, 9, N'637856233835706380-591620290.jpg', CAST(N'2022-04-15T12:43:03.577' AS DateTime), CAST(N'2022-04-15T12:43:03.577' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (18, 9, N'637856233835713335-1293714824.jpg', CAST(N'2022-04-15T12:43:03.580' AS DateTime), CAST(N'2022-04-15T12:43:03.580' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (19, 10, N'637856233863857537772024222.jpg', CAST(N'2022-04-15T12:43:06.393' AS DateTime), CAST(N'2022-04-15T12:43:06.393' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (20, 10, N'637856233863864981-1470853249.jpg', CAST(N'2022-04-15T12:43:06.397' AS DateTime), CAST(N'2022-04-15T12:43:06.397' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (21, 11, N'637856249336460463-91576230.jpg', CAST(N'2022-04-15T13:08:53.923' AS DateTime), CAST(N'2022-04-15T13:08:53.923' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (22, 11, N'637856249336499574700685027.jpg', CAST(N'2022-04-15T13:08:53.953' AS DateTime), CAST(N'2022-04-15T13:08:53.953' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (23, 12, N'6378562497568351651293144746.jpg', CAST(N'2022-04-15T13:09:35.687' AS DateTime), CAST(N'2022-04-15T13:09:35.687' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (24, 12, N'63785624975684194780329086.jpg', CAST(N'2022-04-15T13:09:35.690' AS DateTime), CAST(N'2022-04-15T13:09:35.690' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (25, 13, N'637856251208586702-1352990928.jpg', CAST(N'2022-04-15T13:12:00.863' AS DateTime), CAST(N'2022-04-15T13:12:00.863' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (26, 13, N'637856251208622442-638521336.jpg', CAST(N'2022-04-15T13:12:00.867' AS DateTime), CAST(N'2022-04-15T13:12:00.867' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (27, 14, N'637856251855958962-1784026481.jpg', CAST(N'2022-04-15T13:13:05.600' AS DateTime), CAST(N'2022-04-15T13:13:05.600' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (28, 14, N'6378562518559665571284242737.jpg', CAST(N'2022-04-15T13:13:05.603' AS DateTime), CAST(N'2022-04-15T13:13:05.603' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (29, 15, N'637856257560463332559128257.jpg', CAST(N'2022-04-15T13:22:36.053' AS DateTime), CAST(N'2022-04-15T13:22:36.053' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (30, 15, N'6378562575604707391544673870.jpg', CAST(N'2022-04-15T13:22:36.057' AS DateTime), CAST(N'2022-04-15T13:22:36.057' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (31, 16, N'6378562814772202731853590860.jpg', CAST(N'2022-04-15T14:02:28.463' AS DateTime), CAST(N'2022-04-15T14:02:28.463' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (32, 16, N'6378562814772473461101259801.jpg', CAST(N'2022-04-15T14:02:28.497' AS DateTime), CAST(N'2022-04-15T14:02:28.497' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (33, 20, N'637856289989901232419622337.jpg', CAST(N'2022-04-15T14:16:38.997' AS DateTime), CAST(N'2022-04-15T14:16:38.997' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (34, 20, N'637856289989908128933402292.jpg', CAST(N'2022-04-15T14:16:39.000' AS DateTime), CAST(N'2022-04-15T14:16:39.000' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (35, 20, N'6378562899899135781749303903.jpg', CAST(N'2022-04-15T14:16:39.000' AS DateTime), CAST(N'2022-04-15T14:16:39.000' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (36, 21, N'637859506279793523-1015980275.jpg', CAST(N'2022-04-19T07:37:08.277' AS DateTime), CAST(N'2022-04-19T07:37:08.277' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (37, 21, N'6378595062798117411434257620.jpg', CAST(N'2022-04-19T07:37:08.307' AS DateTime), CAST(N'2022-04-19T07:37:08.307' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (38, 21, N'637859506279817879-41133375.jpg', CAST(N'2022-04-19T07:37:08.307' AS DateTime), CAST(N'2022-04-19T07:37:08.307' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (1036, 1021, N'637859686574720082499153816.jpg', CAST(N'2022-04-19T12:37:37.703' AS DateTime), CAST(N'2022-04-19T12:37:37.703' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (1037, 1022, N'6378604092000489581641621887.jpg', CAST(N'2022-04-20T08:42:00.223' AS DateTime), CAST(N'2022-04-20T08:42:00.223' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (1038, 1022, N'637860409200067816-305428862.jpg', CAST(N'2022-04-20T08:42:00.243' AS DateTime), CAST(N'2022-04-20T08:42:00.243' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (1039, 1023, N'637872545922982583-853703321.jpg', CAST(N'2022-05-04T09:49:53.120' AS DateTime), CAST(N'2022-05-04T09:49:53.120' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (1040, 1023, N'637872545923025063-1822535263.jpg', CAST(N'2022-05-04T09:49:53.167' AS DateTime), CAST(N'2022-05-04T09:49:53.167' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (1041, 1024, N'637872654486436830-364654478.jpg', CAST(N'2022-05-04T12:50:48.723' AS DateTime), CAST(N'2022-05-04T12:50:48.723' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2041, 2024, N'637873408246886673332034396.jpg', CAST(N'2022-05-05T09:47:04.763' AS DateTime), CAST(N'2022-05-05T09:47:04.763' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2051, 2030, N'6378778012696416801657407489.jpg', CAST(N'2022-05-10T11:48:47.183' AS DateTime), CAST(N'2022-05-10T11:48:47.183' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2052, 2030, N'637877801269666515173183008.jpg', CAST(N'2022-05-10T11:48:47.207' AS DateTime), CAST(N'2022-05-10T11:48:47.207' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2053, 2030, N'637877801269672918560363650.png', CAST(N'2022-05-10T11:48:47.207' AS DateTime), CAST(N'2022-05-10T11:48:47.207' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2054, 2030, N'637877801269826425-390043823.png', CAST(N'2022-05-10T11:48:47.207' AS DateTime), CAST(N'2022-05-10T11:48:47.207' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2055, 2031, N'637877817393829406722248754.jpg', CAST(N'2022-05-10T12:15:39.627' AS DateTime), CAST(N'2022-05-10T12:15:39.627' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2056, 2032, N'637877817477365019-1559784751.jpg', CAST(N'2022-05-10T12:15:47.740' AS DateTime), CAST(N'2022-05-10T12:15:47.740' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2057, 2033, N'637877818046873661748010119.jpg', CAST(N'2022-05-10T12:16:44.693' AS DateTime), CAST(N'2022-05-10T12:16:44.693' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2058, 2034, N'637877818125795633-713352603.jpg', CAST(N'2022-05-10T12:16:52.583' AS DateTime), CAST(N'2022-05-10T12:16:52.583' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2059, 2035, N'6378778181633484851479708002.jpg', CAST(N'2022-05-10T12:16:56.347' AS DateTime), CAST(N'2022-05-10T12:16:56.347' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2060, 2036, N'637877818821344282555867512.jpg', CAST(N'2022-05-10T12:18:02.140' AS DateTime), CAST(N'2022-05-10T12:18:02.140' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2061, 2037, N'637877818860799132-896945089.jpg', CAST(N'2022-05-10T12:18:06.083' AS DateTime), CAST(N'2022-05-10T12:18:06.083' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2062, 2038, N'637877818926053998-1749137869.jpg', CAST(N'2022-05-10T12:18:12.610' AS DateTime), CAST(N'2022-05-10T12:18:12.610' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2063, 2039, N'637877818982801997-936121229.jpg', CAST(N'2022-05-10T12:18:18.287' AS DateTime), CAST(N'2022-05-10T12:18:18.287' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2064, 2039, N'63787781898280998486014899.jpg', CAST(N'2022-05-10T12:18:18.290' AS DateTime), CAST(N'2022-05-10T12:18:18.290' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2065, 2039, N'637877818982817701994968657.jpg', CAST(N'2022-05-10T12:18:18.290' AS DateTime), CAST(N'2022-05-10T12:18:18.290' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2066, 2040, N'637877819054694443-201771412.jpg', CAST(N'2022-05-10T12:18:25.473' AS DateTime), CAST(N'2022-05-10T12:18:25.473' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2067, 2040, N'637877819054705073993757797.jpg', CAST(N'2022-05-10T12:18:25.477' AS DateTime), CAST(N'2022-05-10T12:18:25.477' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2068, 2041, N'637877821137378790-1165011349.jpg', CAST(N'2022-05-10T12:21:53.743' AS DateTime), CAST(N'2022-05-10T12:21:53.743' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2069, 2041, N'637877821137400613-912186037.jpg', CAST(N'2022-05-10T12:21:53.747' AS DateTime), CAST(N'2022-05-10T12:21:53.747' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2070, 2042, N'637877821255900613-538134484.jpg', CAST(N'2022-05-10T12:22:05.593' AS DateTime), CAST(N'2022-05-10T12:22:05.593' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2071, 2042, N'6378778212559096191003905528.jpg', CAST(N'2022-05-10T12:22:05.593' AS DateTime), CAST(N'2022-05-10T12:22:05.593' AS DateTime))
INSERT [dbo].[image] ([id], [album_id], [image_url], [created_on], [updated_on]) VALUES (2072, 2043, N'637878648156142559-651263454.png', CAST(N'2022-05-11T11:20:15.640' AS DateTime), CAST(N'2022-05-11T11:20:15.640' AS DateTime))
SET IDENTITY_INSERT [dbo].[image] OFF
GO
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (1, N'Test1', N'test1@gmail.com', N'$2a$11$QOe2uKJwFRQCVWISK3RdI.QbI8OmUjRPDQYETStCXXAsbU.371eN.', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-03-31T12:51:40.413' AS DateTime), CAST(N'2022-03-31T12:51:40.413' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (3, N'Test3', N'test3@gmail.com', N'$2a$11$atDG4s3Gukz29poKpgAdd.wbB4LUawlhgujB2j84d0sAKFt0x7/m6', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-03-31T14:07:11.713' AS DateTime), CAST(N'2022-03-31T14:07:11.713' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (5, N'updatedusername', N'updated@updated.com', N'updated', 0, 0, 0, N'637872574978181015-13021323.jpg', N'image.png', CAST(N'2022-03-31T13:15:50.123' AS DateTime), CAST(N'2022-05-04T10:38:18.697' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (6, N'asd', N'asd@gmail.com', N'$2a$11$kmG2VTWYEqU3ozgtGvdlP.9VTTFzZFdkDgu.dh.3QMvxfm5ulQafW', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-01T12:18:50.287' AS DateTime), CAST(N'2022-04-01T12:18:50.287' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (7, N'asd1', N'asd@gmail.com', N'$2a$11$AGvkRx8.8fQKqMR07W645e5SiM5vF.BJoB2unR3JkNq5oGd59rYK2', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-05T14:03:01.753' AS DateTime), CAST(N'2022-04-05T14:03:01.753' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (8, N'asd2', N'asd@gmail.com', N'$2a$11$wDHS1CEQs3g6N6/y4jL7tOii9SAKtu.50wXROFA5uT5As9gXLg/ly', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-05T14:03:27.347' AS DateTime), CAST(N'2022-04-05T14:03:27.347' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (9, N'asd3', N'asd@gmail.com', N'$2a$11$qcWMEQkmDDRhWloZu6UFZOpzr/0g1j4O2bGSbnIbdBQvnBAMGW1g.', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-05T15:02:13.633' AS DateTime), CAST(N'2022-04-05T15:02:13.633' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (10, N'imagetest', N'asd@gmail.com', N'$2a$11$bbX3MhlDckT236.qeGFqCOrWPD2SGytPaMASs3MWtmtq.77CId2fG', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T07:39:49.817' AS DateTime), CAST(N'2022-04-06T07:39:49.817' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (11, N'imagetest1', N'asd@gmail.com', N'$2a$11$66m6sKjItkRPhXKzB84I6.0iCYTP90ydJNe5iEHJwOoG7vFqtDD92', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T07:43:25.233' AS DateTime), CAST(N'2022-04-06T07:43:25.233' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (12, N'register1', N'register1@gmail.com', N'$2a$11$eYQ3RcwqAf7S9DxP1htbMetumrQ2M0gHDK/bPBj.VuBj0g8xcOYS6', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T07:55:33.200' AS DateTime), CAST(N'2022-04-06T07:55:33.200' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (13, N'testtest1', N'asd@gmail.com', N'$2a$11$.hpF25RUHjujkcwAD3AxFuJb3nUbNYTg7/ZCFbnYmU.2qeoNhlyH2', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T08:24:53.867' AS DateTime), CAST(N'2022-04-06T08:24:53.867' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (14, N'ecs', N'asd@gmail.com', N'$2a$11$NqCl2xIgDA8RUyMmCSmI1.uy.E4dTE8gLlP3czgoTQSLp8svVjLiS', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T11:05:20.457' AS DateTime), CAST(N'2022-04-06T11:05:20.457' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (15, N'ecs1', N'asd@gmail.com', N'$2a$11$YmX8OT/sdAMd8JYjZ5jX5e/qXUBr4jqxOJIYHYKXE4uXmLZBvp5y6', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T11:07:43.363' AS DateTime), CAST(N'2022-04-06T11:07:43.363' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (16, N'ecs111', N'asd@gmail.com', N'$2a$11$ESwbU0klRKpK2wvfAb57.eYPek96mLI4ihf4T9zyO8fijUgSgk1aW', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T11:10:26.707' AS DateTime), CAST(N'2022-04-06T11:10:26.707' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (17, N'Bruh', N'pijocey904@xasems.com', N'$2a$11$8rgxXBGnoXHuH.ecy6Ag.eHGA2nml2b0qNCVelijQ.Kjwk8AYyCae', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T12:55:42.893' AS DateTime), CAST(N'2022-04-06T12:55:42.893' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (18, N'Bruh1', N'pijocey904@xasems.com', N'$2a$11$59BuPT/aK4M8IJwmXBVLLuhl54ou2tzLpAHb/r756YvN0oKT6bLs6', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T12:58:28.527' AS DateTime), CAST(N'2022-04-06T12:58:28.527' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (19, N'Bruh2', N'pijocey904@xasems.com', N'$2a$11$18NQ18oZbYJ4f8kb3Ppln.GU27jFmX.x7yQ4994TqdyaPq6t2ld7C', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T13:06:27.117' AS DateTime), CAST(N'2022-04-06T13:06:27.117' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (20, N'cilag37527@xasems.com', N'cilag37527@xasems.com', N'$2a$11$CKXOXw242d5Cn86EvRe3AOEuxMBgle.fHzl7Ig9is7/iDJUtiMyc2', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T13:56:26.927' AS DateTime), CAST(N'2022-04-06T13:56:26.927' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (21, N'fojadoc855@vsooc.com', N'fojadoc855@vsooc.com', N'$2a$11$PVe5bwH2KCtqk5ePkvL6euf3mbowfuSFC7ii5TZb0z9TsE5Ns/5Te', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-06T13:59:53.157' AS DateTime), CAST(N'2022-04-06T13:59:53.157' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (22, N'hepoheb660@vsooc.com', N'hepoheb660@vsooc.com', N'$2a$11$s0Y6Y67ecl7vSPmhyh1hZeHYpVPfHlQGM6nhH643BJysiFpiZUWuC', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-06T14:18:01.560' AS DateTime), CAST(N'2022-04-07T07:49:20.603' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (23, N'hehix58483@xasems.com', N'hehix58483@xasems.com', N'$2a$11$oQcwV1uKmwkSqTl6ViNu7eVdhV0dD-u1ffddbiK7ZGS-Go8GWByJ6', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T10:50:45.373' AS DateTime), CAST(N'2022-04-07T10:50:57.360' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (24, N'lefofis327@yeafam.com', N'lefofis327@yeafam.com', N'$2a$11$psyJyvdJ8xD9m7jukDfa3.Sova1uNr4cI3mvzxGwDfSo9FWbxx7NG', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-07T10:52:05.387' AS DateTime), CAST(N'2022-04-07T10:52:05.387' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (25, N'cefafir437@xasems.com', N'cefafir437@xasems.com', N'$2a$11$E.UgqBgald33WjPhy4oaFusB6Gd.UaKPSKuu48m.BIVOvWVJIsEce', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T10:56:15.100' AS DateTime), CAST(N'2022-04-07T10:56:30.643' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (26, N'demovo4204@yeafam.com', N'demovo4204@yeafam.com', N'$2a$11$ysnYFGusmmiu.Hkuf5TMU.LYoftCFxg4GcgpJBW77OlmK1zAd7FYO', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-07T10:58:08.790' AS DateTime), CAST(N'2022-04-07T10:58:08.790' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (27, N'cagoc56360@vsooc.com', N'cagoc56360@vsooc.com', N'$2a$11$U501mu4YQ8HEBFunKKp2eeyjrbxc.e.QPjrWmktKW7HH5s447mrVm', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T11:02:56.250' AS DateTime), CAST(N'2022-04-07T11:03:44.107' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (28, N'kosalot293@whwow.com', N'kosalot293@whwow.com', N'$2a$11$hxc49As9tlxmdWsxouMyd.ETCYuhiAyBKP0ULGJahCKiad1OXkgvi', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T11:06:23.013' AS DateTime), CAST(N'2022-04-07T11:06:41.707' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (29, N'degavoj973@xasems.com', N'degavoj973@xasems.com', N'$2a$11$QsAGFWPT05dRLF/fQY7fUOVXzNC.r7J5uYJCzZ9Tqt63MfkR410SG', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T11:07:21.120' AS DateTime), CAST(N'2022-04-07T11:07:29.907' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (30, N'tadidep566@whwow.com', N'tadidep566@whwow.com', N'$2a$11$Jku91p//5rtrJq32IdpCvOei2oPTs9Ls4PlAi1KuMFiwn1zV/0IO6', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T11:08:01.613' AS DateTime), CAST(N'2022-04-07T11:08:09.520' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (31, N'verine9679@whwow.com', N'verine9679@whwow.com', N'$2a$11$Mvg1UaUx04Y8MmDdevJghe5x093yO9JHmCQo0oP3wkbGbogBM38zm', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T11:09:48.500' AS DateTime), CAST(N'2022-04-07T11:09:56.640' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (32, N'doyacaw848@whwow.com', N'doyacaw848@whwow.com', N'$2a$11$JY3cDjZFbu98UCwmig5ssu26TTJTvXa3i5jUJ8RoGsPnH0qAlTJLu', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T11:11:03.523' AS DateTime), CAST(N'2022-04-07T11:11:13.880' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (33, N'desajif580@yeafam.com', N'desajif580@yeafam.com', N'$2a$11$pAIitva/jgePXhiJKHTdVuhyb6KMUCDk.l4gpNZ5fPR3jP/pWeXwa', 0, 1, 1, N'default.svg', N'default.svg', CAST(N'2022-04-07T13:02:48.720' AS DateTime), CAST(N'2022-05-12T10:42:51.023' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (34, N'naniwe6843@eosbuzz.com', N'naniwe6843@eosbuzz.com', N'$2a$11$Oo9hWkszNu9ZeVZs3Y2XHOmoEAwkv3VGISOohtgx2m3P518zLUX6a', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-13T09:48:14.850' AS DateTime), CAST(N'2022-04-13T09:48:14.850' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (35, N'pafapim911@eosbuzz.com', N'pafapim911@eosbuzz.com', N'$2a$11$1XMEqraABzGaD3DTIiwrJOWem6P7wmbVrh3nbo3rZqDcqhRx5rlNK', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-13T09:53:30.230' AS DateTime), CAST(N'2022-04-13T09:53:30.230' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (36, N'jodis96737@carsik.com', N'jodis96737@carsik.com', N'$2a$11$NxrdJKSn.4IwRKMZiOHsQeGvnWHMNvYXX3LnFueWFNcFWx4oT8iZO', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-13T11:48:45.290' AS DateTime), CAST(N'2022-04-13T11:48:45.290' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (37, N'yafedoj942@carsik.com', N'yafedoj942@carsik.com', N'$2a$11$aKIPkybHp0a/.4Qc3CeV/uHc68oQdkhSP8q3VwfwLDMn.uj6EuULy', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-13T12:09:42.183' AS DateTime), CAST(N'2022-04-13T12:09:51.293' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (38, N'haced37163@leafzie.com', N'haced37163@leafzie.com', N'$2a$11$3hgQKdbQswOcA/TtgRHA8.lACTZl.k1JV3NialVNS/4./MEuXAWMC', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-04-13T12:11:08.950' AS DateTime), CAST(N'2022-04-13T12:11:16.743' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (43, N'jotoji6376@leafzie.com', N'jotoji6376@leafzie.com', N'$2a$11$sjNj3zl4jLwhfTeRhz199u60u8iRMcfCwtEYY77emCbNYWNZZJUmG', 0, 0, 0, N'default.svg', N'default.svg', CAST(N'2022-04-18T07:51:20.937' AS DateTime), CAST(N'2022-04-18T07:51:20.937' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (44, N'lofor30785@carsik.com', N'lofor30785@carsik.com', N'$2a$11$ex5pJaEo8YkcQbD/X6OlmON2cP8JOKltc4ZKOk8/EOv82SMtPZr6.', 1, 0, 1, N'637877693241836339-476812911.jpg', N'637877693105322509-1895036430.jpg', CAST(N'2022-04-18T12:42:17.170' AS DateTime), CAST(N'2022-05-10T08:48:44.187' AS DateTime))
INSERT [dbo].[user] ([id], [username], [email], [password], [role], [is_banned], [is_email_confirmed], [profile_image], [cover_image], [created_on], [updated_on]) VALUES (1043, N'kilinay267@bunlets.com', N'kilinay267@bunlets.com', N'$2a$11$QBMs0vW6AFE7wd.DC3uuleCKTgUaMh68NAbeYd1HBOucaXo.TkDbq', 0, 0, 1, N'default.svg', N'default.svg', CAST(N'2022-05-11T11:19:14.073' AS DateTime), CAST(N'2022-05-12T09:23:03.900' AS DateTime))
GO
ALTER TABLE [dbo].[album]  WITH CHECK ADD  CONSTRAINT [FK_album_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[album] CHECK CONSTRAINT [FK_album_user]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_comment_album] FOREIGN KEY([album_id])
REFERENCES [dbo].[album] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comment_album]
GO
ALTER TABLE [dbo].[email_confirm]  WITH CHECK ADD  CONSTRAINT [FK_email_confirm_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[email_confirm] CHECK CONSTRAINT [FK_email_confirm_user]
GO
ALTER TABLE [dbo].[image]  WITH CHECK ADD  CONSTRAINT [FK_image_album] FOREIGN KEY([album_id])
REFERENCES [dbo].[album] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[image] CHECK CONSTRAINT [FK_image_album]
GO
USE [master]
GO
ALTER DATABASE [FacebookCloneDB] SET  READ_WRITE 
GO
