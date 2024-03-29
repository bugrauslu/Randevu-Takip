USE [master]
GO
/****** Object:  Database [randevu_takip]    Script Date: 23.01.2021 16:22:01 ******/
CREATE DATABASE [randevu_takip]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'randevu_takip', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\randevu_takip.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'randevu_takip_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\randevu_takip_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [randevu_takip] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [randevu_takip].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [randevu_takip] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [randevu_takip] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [randevu_takip] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [randevu_takip] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [randevu_takip] SET ARITHABORT OFF 
GO
ALTER DATABASE [randevu_takip] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [randevu_takip] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [randevu_takip] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [randevu_takip] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [randevu_takip] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [randevu_takip] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [randevu_takip] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [randevu_takip] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [randevu_takip] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [randevu_takip] SET  DISABLE_BROKER 
GO
ALTER DATABASE [randevu_takip] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [randevu_takip] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [randevu_takip] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [randevu_takip] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [randevu_takip] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [randevu_takip] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [randevu_takip] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [randevu_takip] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [randevu_takip] SET  MULTI_USER 
GO
ALTER DATABASE [randevu_takip] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [randevu_takip] SET DB_CHAINING OFF 
GO
ALTER DATABASE [randevu_takip] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [randevu_takip] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [randevu_takip] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [randevu_takip] SET QUERY_STORE = OFF
GO
USE [randevu_takip]
GO
/****** Object:  Table [dbo].[randevular]    Script Date: 23.01.2021 16:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[randevular](
	[randev_tarihi] [date] NULL,
	[randevu_saati] [nvarchar](50) NULL,
	[hasta_id] [int] NULL,
	[doktor_id] [int] NULL,
	[bolum_id] [int] NULL,
	[randevu_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_randevular] PRIMARY KEY CLUSTERED 
(
	[randevu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[kayitguncelle]    Script Date: 23.01.2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[kayitguncelle]
AS
SELECT        TOP (1) PERCENT randevu_id
FROM            dbo.randevular
ORDER BY randevu_id DESC
GO
/****** Object:  Table [dbo].[bolum]    Script Date: 23.01.2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bolum](
	[bolum_id] [int] IDENTITY(1,1) NOT NULL,
	[bolum_adı] [nvarchar](50) NULL,
 CONSTRAINT [PK_bolum] PRIMARY KEY CLUSTERED 
(
	[bolum_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doktorlar]    Script Date: 23.01.2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doktorlar](
	[doktor_id] [int] IDENTITY(1,1) NOT NULL,
	[doktor_adı] [nvarchar](50) NULL,
	[doktor_soyadı] [nvarchar](50) NULL,
	[doktor_bolumu] [int] NOT NULL,
 CONSTRAINT [PK_doktorlar] PRIMARY KEY CLUSTERED 
(
	[doktor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hastalar]    Script Date: 23.01.2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hastalar](
	[hasta_id] [int] IDENTITY(1,1) NOT NULL,
	[adı] [nvarchar](50) NULL,
	[soyadı] [nvarchar](50) NULL,
	[tc_no] [nvarchar](11) NULL,
	[telefon_no] [nvarchar](11) NULL,
 CONSTRAINT [PK_hastalar] PRIMARY KEY CLUSTERED 
(
	[hasta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanicilar]    Script Date: 23.01.2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanicilar](
	[kullanici_id] [int] IDENTITY(1,1) NOT NULL,
	[kullanici_ad] [nvarchar](50) NULL,
	[kullanici_sifre] [nvarchar](50) NULL,
 CONSTRAINT [PK_kullanicilar] PRIMARY KEY CLUSTERED 
(
	[kullanici_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[randevular]  WITH CHECK ADD  CONSTRAINT [FK_randevular_bolum] FOREIGN KEY([doktor_id])
REFERENCES [dbo].[bolum] ([bolum_id])
GO
ALTER TABLE [dbo].[randevular] CHECK CONSTRAINT [FK_randevular_bolum]
GO
ALTER TABLE [dbo].[randevular]  WITH CHECK ADD  CONSTRAINT [FK_randevular_doktorlar] FOREIGN KEY([doktor_id])
REFERENCES [dbo].[doktorlar] ([doktor_id])
GO
ALTER TABLE [dbo].[randevular] CHECK CONSTRAINT [FK_randevular_doktorlar]
GO
ALTER TABLE [dbo].[randevular]  WITH CHECK ADD  CONSTRAINT [FK_randevular_hastalar] FOREIGN KEY([hasta_id])
REFERENCES [dbo].[hastalar] ([hasta_id])
GO
ALTER TABLE [dbo].[randevular] CHECK CONSTRAINT [FK_randevular_hastalar]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[22] 2[19] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "randevular"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'kayitguncelle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'kayitguncelle'
GO
USE [master]
GO
ALTER DATABASE [randevu_takip] SET  READ_WRITE 
GO
