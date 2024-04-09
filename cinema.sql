USE [master]
GO
/****** Object:  Database [cinema]    Script Date: 4/10/2024 12:10:00 AM ******/
CREATE DATABASE [cinema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'film', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\film.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'film_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\film_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [cinema] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cinema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cinema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cinema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cinema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cinema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cinema] SET ARITHABORT OFF 
GO
ALTER DATABASE [cinema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cinema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cinema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cinema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cinema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cinema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cinema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cinema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cinema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cinema] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cinema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cinema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cinema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cinema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cinema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cinema] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cinema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cinema] SET RECOVERY FULL 
GO
ALTER DATABASE [cinema] SET  MULTI_USER 
GO
ALTER DATABASE [cinema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cinema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cinema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cinema] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cinema] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cinema] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'cinema', N'ON'
GO
ALTER DATABASE [cinema] SET QUERY_STORE = ON
GO
ALTER DATABASE [cinema] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [cinema]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[makhachhang] [nchar](10) NOT NULL,
	[tenkhachhang] [nchar](50) NULL,
	[sdt] [nchar](15) NULL,
	[diachi] [nchar](10) NULL,
	[ngaysinh] [date] NULL,
 CONSTRAINT [PK_khachhang] PRIMARY KEY CLUSTERED 
(
	[makhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lichchieu]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lichchieu](
	[id] [nchar](10) NOT NULL,
	[thoigianchieu] [datetime] NULL,
	[idphong] [nchar](10) NULL,
	[giave] [money] NULL,
	[trangthai] [int] NULL,
 CONSTRAINT [PK_lichchieu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaive]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaive](
	[maloaive] [nchar](10) NOT NULL,
	[tenloaive] [nvarchar](10) NULL,
	[dongia] [int] NULL,
 CONSTRAINT [PK_loaive] PRIMARY KEY CLUSTERED 
(
	[maloaive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nv]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nv](
	[manv] [nchar](10) NOT NULL,
	[tennv] [nchar](10) NULL,
	[diachi] [nchar](50) NULL,
	[sdt] [nchar](30) NULL,
	[role] [nchar](10) NULL,
 CONSTRAINT [PK_nv] PRIMARY KEY CLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phim]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phim](
	[maphim] [nchar](20) NOT NULL,
	[tenphim] [nchar](50) NULL,
	[mota] [nchar](200) NULL,
	[thoiluong] [float] NULL,
	[ngaykhoichieu] [date] NULL,
	[ngayketthuc] [date] NULL,
	[quocgia] [nchar](50) NULL,
	[daodien] [nchar](30) NULL,
	[namsanxuat] [int] NULL,
	[theloai] [nchar](30) NULL,
	[banner] [nchar](30) NULL,
 CONSTRAINT [PK_phim] PRIMARY KEY CLUSTERED 
(
	[maphim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phongchieu]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phongchieu](
	[maphong] [nchar](10) NOT NULL,
	[tenphong] [nchar](10) NULL,
	[soluongghe] [int] NULL,
	[soghemoihang] [int] NULL,
	[tinhtrang] [int] NULL,
 CONSTRAINT [PK_phongchieu] PRIMARY KEY CLUSTERED 
(
	[maphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[theloai]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[theloai](
	[matheloai] [nchar](10) NOT NULL,
	[tentheloai] [nchar](10) NULL,
	[mota] [nchar](10) NULL,
 CONSTRAINT [PK_theloai] PRIMARY KEY CLUSTERED 
(
	[matheloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thongtinve]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongtinve](
	[mave] [nchar](10) NOT NULL,
	[maphong] [nchar](10) NULL,
	[maphim] [nchar](10) NULL,
	[xuatchieu] [datetime] NULL,
 CONSTRAINT [PK_thongtinve] PRIMARY KEY CLUSTERED 
(
	[mave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[username] [nchar](10) NOT NULL,
	[password] [nchar](10) NULL,
	[hoTen] [nchar](30) NULL,
	[diaChi] [nchar](30) NULL,
	[sdt] [nchar](13) NULL,
	[role] [nchar](5) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ve]    Script Date: 4/10/2024 12:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ve](
	[mave] [nchar](10) NOT NULL,
	[maloaive] [nchar](10) NULL,
	[manhanvien] [nchar](10) NULL,
	[makhachhang] [nchar](10) NULL,
	[ghe] [int] NULL,
	[ngaybanve] [date] NULL,
 CONSTRAINT [PK_ve] PRIMARY KEY CLUSTERED 
(
	[mave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[thongtinve]  WITH CHECK ADD  CONSTRAINT [FK_thongtinve_phongchieu] FOREIGN KEY([maphong])
REFERENCES [dbo].[phongchieu] ([maphong])
GO
ALTER TABLE [dbo].[thongtinve] CHECK CONSTRAINT [FK_thongtinve_phongchieu]
GO
ALTER TABLE [dbo].[thongtinve]  WITH CHECK ADD  CONSTRAINT [FK_thongtinve_ve1] FOREIGN KEY([mave])
REFERENCES [dbo].[ve] ([mave])
GO
ALTER TABLE [dbo].[thongtinve] CHECK CONSTRAINT [FK_thongtinve_ve1]
GO
ALTER TABLE [dbo].[ve]  WITH CHECK ADD  CONSTRAINT [FK_ve_khachhang1] FOREIGN KEY([makhachhang])
REFERENCES [dbo].[khachhang] ([makhachhang])
GO
ALTER TABLE [dbo].[ve] CHECK CONSTRAINT [FK_ve_khachhang1]
GO
ALTER TABLE [dbo].[ve]  WITH CHECK ADD  CONSTRAINT [FK_ve_loaive1] FOREIGN KEY([maloaive])
REFERENCES [dbo].[loaive] ([maloaive])
GO
ALTER TABLE [dbo].[ve] CHECK CONSTRAINT [FK_ve_loaive1]
GO
ALTER TABLE [dbo].[ve]  WITH CHECK ADD  CONSTRAINT [FK_ve_nv1] FOREIGN KEY([manhanvien])
REFERENCES [dbo].[nv] ([manv])
GO
ALTER TABLE [dbo].[ve] CHECK CONSTRAINT [FK_ve_nv1]
GO
USE [master]
GO
ALTER DATABASE [cinema] SET  READ_WRITE 
GO
