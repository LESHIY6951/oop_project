USE [master]
GO
/****** Object:  Database [qwe]    Script Date: 14.11.2023 22:30:54 ******/
CREATE DATABASE [qwe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [qwe] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [qwe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [qwe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [qwe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [qwe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [qwe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [qwe] SET ARITHABORT OFF 
GO
ALTER DATABASE [qwe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [qwe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [qwe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [qwe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [qwe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [qwe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [qwe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [qwe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [qwe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [qwe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [qwe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [qwe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [qwe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [qwe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [qwe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [qwe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [qwe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [qwe] SET RECOVERY FULL 
GO
ALTER DATABASE [qwe] SET  MULTI_USER 
GO
ALTER DATABASE [qwe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [qwe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [qwe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [qwe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [qwe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [qwe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'qwe', N'ON'
GO
ALTER DATABASE [qwe] SET QUERY_STORE = ON
GO
ALTER DATABASE [qwe] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [qwe]
GO
/****** Object:  Table [dbo].[cart]    Script Date: 14.11.2023 22:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart](
	[cart_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[col] [int] NULL,
 CONSTRAINT [PK_cart_item_id] PRIMARY KEY CLUSTERED 
(
	[cart_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[certificate]    Script Date: 14.11.2023 22:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[certificate](
	[cert_id] [int] IDENTITY(5,1) NOT NULL,
	[name] [nvarchar](45) NULL,
 CONSTRAINT [PK_certificate_cert_id] PRIMARY KEY CLUSTERED 
(
	[cert_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [certificate$cert_id_UNIQUE] UNIQUE NONCLUSTERED 
(
	[cert_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[forum]    Script Date: 14.11.2023 22:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[forum](
	[forum_id] [int] IDENTITY(1,1) NOT NULL,
	[cert_id] [int] NOT NULL,
	[name] [nvarchar](45) NULL,
	[score] [int] NULL,
	[text] [nvarchar](45) NULL,
	[likes] [int] NULL,
	[dislikes] [int] NULL,
 CONSTRAINT [PK_forum_1] PRIMARY KEY NONCLUSTERED 
(
	[forum_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [forum$cert_id_UNIQUE]    Script Date: 14.11.2023 22:30:55 ******/
CREATE CLUSTERED INDEX [forum$cert_id_UNIQUE] ON [dbo].[forum]
(
	[cert_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[history]    Script Date: 14.11.2023 22:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[history](
	[user_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[total_cost] [int] NULL,
	[date] [datetime] NULL,
	[history_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_history] PRIMARY KEY CLUSTERED 
(
	[history_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 14.11.2023 22:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[user_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[total_cost] [int] NULL,
	[card_num] [nvarchar](45) NULL,
	[CVV] [nvarchar](45) NULL,
	[card_name] [nvarchar](45) NULL,
	[data] [datetime] NOT NULL,
	[order_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_order_1] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 14.11.2023 22:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[item_id] [int] NOT NULL,
	[item_name] [nvarchar](max) NOT NULL,
	[item_description] [nvarchar](max) NOT NULL,
	[item_cost] [int] NOT NULL,
	[item_img] [nvarchar](50) NULL,
 CONSTRAINT [PK_products_item_id] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [products$item_id_UNIQUE] UNIQUE NONCLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.11.2023 22:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cert_id] [nvarchar](50) NULL,
	[login] [nvarchar](45) NOT NULL,
	[password] [nvarchar](45) NOT NULL,
	[name] [nvarchar](45) NOT NULL,
	[email] [nvarchar](45) NULL,
	[number] [nvarchar](45) NOT NULL,
	[address] [nvarchar](45) NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_users__id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [users$_id_UNIQUE] UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [users$login_UNIQUE] UNIQUE NONCLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [users$CERTIFICATE_cert_id_UNIQUE]    Script Date: 14.11.2023 22:30:55 ******/
CREATE NONCLUSTERED INDEX [users$CERTIFICATE_cert_id_UNIQUE] ON [dbo].[User]
(
	[cert_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cart] ADD  CONSTRAINT [DF__cart__total_cost__70DDC3D8]  DEFAULT (NULL) FOR [col]
GO
ALTER TABLE [dbo].[certificate] ADD  CONSTRAINT [DF__certificat__name__52593CB8]  DEFAULT (NULL) FOR [name]
GO
ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__name__01142BA1]  DEFAULT (NULL) FOR [name]
GO
ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__score__02084FDA]  DEFAULT (NULL) FOR [score]
GO
ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__text__02FC7413]  DEFAULT (NULL) FOR [text]
GO
ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__likes__03F0984C]  DEFAULT (NULL) FOR [likes]
GO
ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__dislikes__04E4BC85]  DEFAULT (NULL) FOR [dislikes]
GO
ALTER TABLE [dbo].[history] ADD  CONSTRAINT [DF__order_his__total__7C4F7684]  DEFAULT (NULL) FOR [total_cost]
GO
ALTER TABLE [dbo].[history] ADD  CONSTRAINT [DF__order_hist__date__7D439ABD]  DEFAULT (NULL) FOR [date]
GO
ALTER TABLE [dbo].[order] ADD  CONSTRAINT [DF__order__total_cos__75A278F5]  DEFAULT (NULL) FOR [total_cost]
GO
ALTER TABLE [dbo].[order] ADD  CONSTRAINT [DF__order__card_num__76969D2E]  DEFAULT (NULL) FOR [card_num]
GO
ALTER TABLE [dbo].[order] ADD  CONSTRAINT [DF__order__CVV__778AC167]  DEFAULT (NULL) FOR [CVV]
GO
ALTER TABLE [dbo].[order] ADD  CONSTRAINT [DF__order__card_name__787EE5A0]  DEFAULT (NULL) FOR [card_name]
GO
ALTER TABLE [dbo].[order] ADD  CONSTRAINT [DF__order__data__797309D9]  DEFAULT (NULL) FOR [data]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__email__5812160E]  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__address__59063A47]  DEFAULT (NULL) FOR [address]
GO
ALTER TABLE [dbo].[forum]  WITH NOCHECK ADD  CONSTRAINT [forum$fk_FORUM_CERTIFICATE1] FOREIGN KEY([cert_id])
REFERENCES [dbo].[certificate] ([cert_id])
GO
ALTER TABLE [dbo].[forum] CHECK CONSTRAINT [forum$fk_FORUM_CERTIFICATE1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.cart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.certificate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'certificate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.forum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'forum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.order_history' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'history'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.`order`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.products' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'products'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.users' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User'
GO
USE [master]
GO
ALTER DATABASE [qwe] SET  READ_WRITE 
GO
