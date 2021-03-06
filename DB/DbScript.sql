USE [master]
GO
/****** Object:  Database [messenger]    Script Date: 20.10.2018 21:45:47 ******/
CREATE DATABASE [messenger]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [messenger].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [messenger] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [messenger] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [messenger] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [messenger] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [messenger] SET ARITHABORT OFF 
GO
ALTER DATABASE [messenger] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [messenger] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [messenger] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [messenger] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [messenger] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [messenger] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [messenger] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [messenger] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [messenger] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [messenger] SET  DISABLE_BROKER 
GO
ALTER DATABASE [messenger] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [messenger] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [messenger] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [messenger] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [messenger] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [messenger] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [messenger] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [messenger] SET RECOVERY FULL 
GO
ALTER DATABASE [messenger] SET  MULTI_USER 
GO
ALTER DATABASE [messenger] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [messenger] SET DB_CHAINING OFF 
GO
USE [messenger]
GO
/****** Object:  Table [dbo].[BlackList]    Script Date: 20.10.2018 21:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackList](
	[BlackListId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BlockedUserId] [int] NOT NULL,
 CONSTRAINT [PK_BlackList] PRIMARY KEY CLUSTERED 
(
	[BlackListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 20.10.2018 21:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLog] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 20.10.2018 21:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LogType] [smallint] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[CreatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 20.10.2018 21:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[FromUserId] [int] NOT NULL,
	[ToUserId] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20.10.2018 21:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BlackList] ON 
GO
INSERT [dbo].[BlackList] ([BlackListId], [UserId], [BlockedUserId]) VALUES (1, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[BlackList] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 
GO
INSERT [dbo].[Message] ([MessageId], [FromUserId], [ToUserId], [Content], [CreatedTime]) VALUES (1, 1, 2, N'Hi', CAST(N'2018-10-19T16:05:16.520' AS DateTime))
GO
INSERT [dbo].[Message] ([MessageId], [FromUserId], [ToUserId], [Content], [CreatedTime]) VALUES (2, 2, 2, N'Hi', CAST(N'2018-10-19T17:37:08.650' AS DateTime))
GO
INSERT [dbo].[Message] ([MessageId], [FromUserId], [ToUserId], [Content], [CreatedTime]) VALUES (3, 2, 2, N'Hi', CAST(N'2018-10-19T17:37:29.930' AS DateTime))
GO
INSERT [dbo].[Message] ([MessageId], [FromUserId], [ToUserId], [Content], [CreatedTime]) VALUES (4, 1, 2, N'Hi', CAST(N'2018-10-19T17:37:41.957' AS DateTime))
GO
INSERT [dbo].[Message] ([MessageId], [FromUserId], [ToUserId], [Content], [CreatedTime]) VALUES (5, 1, 2, N'Hi', CAST(N'2018-10-19T17:56:11.863' AS DateTime))
GO
INSERT [dbo].[Message] ([MessageId], [FromUserId], [ToUserId], [Content], [CreatedTime]) VALUES (6, 1, 2, N'Hi', CAST(N'2018-10-19T17:56:47.023' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (1, N'MustafaTekeraslan', N'1903')
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (2, N'Tester', N'1')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[ErrorLog] ADD  CONSTRAINT [DF_ErrorLog_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_CreatedDate]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[BlackList]  WITH CHECK ADD  CONSTRAINT [FK_BlackList_User] FOREIGN KEY([BlockedUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[BlackList] CHECK CONSTRAINT [FK_BlackList_User]
GO
ALTER TABLE [dbo].[BlackList]  WITH CHECK ADD  CONSTRAINT [FK_BlackList_User1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[BlackList] CHECK CONSTRAINT [FK_BlackList_User1]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [ent] FOREIGN KEY([ToUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [ent]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([FromUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
USE [master]
GO
ALTER DATABASE [messenger] SET  READ_WRITE 
GO
