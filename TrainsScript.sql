USE [master]
GO
/****** Object:  Database [TrainsDB]    Script Date: 01.03.2022 4:25:28 ******/
CREATE DATABASE [TrainsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrainsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TrainsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrainsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TrainsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TrainsDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrainsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrainsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrainsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrainsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrainsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrainsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrainsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrainsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrainsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrainsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrainsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrainsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrainsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrainsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrainsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrainsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrainsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrainsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrainsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrainsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrainsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrainsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrainsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrainsDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrainsDB] SET  MULTI_USER 
GO
ALTER DATABASE [TrainsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrainsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrainsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrainsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrainsDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrainsDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TrainsDB] SET QUERY_STORE = OFF
GO
USE [TrainsDB]
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[TelNum] [nvarchar](11) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[TelNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Train]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train](
	[ID] [int] NOT NULL,
	[Origin] [nvarchar](50) NOT NULL,
	[Destination] [nvarchar](50) NOT NULL,
	[DepartTime] [datetime] NOT NULL,
	[ArriveTime] [datetime] NOT NULL,
	[MaxCapacity] [int] NOT NULL,
	[TicketCost] [int] NOT NULL,
 CONSTRAINT [PK_Train] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ID] [int] NOT NULL,
	[UserTelNum] [nvarchar](11) NOT NULL,
	[TrainID] [int] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[BuyerTickets]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BuyerTickets]
AS
SELECT Buyer.FirstName, Buyer.LastName, Train.Origin, Train.Destination
FROM Buyer, Ticket, Train
WHERE Buyer.TelNum=Ticket.UserTelNum AND Ticket.TrainID=Train.ID
GO
/****** Object:  View [dbo].[TicketCosts]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TicketCosts]
AS
SELECT Ticket.ID, Train.TicketCost
FROM Ticket, Train
WHERE Ticket.TrainID=Train.ID
GO
/****** Object:  View [dbo].[IndirectTrains]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[IndirectTrains] AS
SELECT 
T1.ID AS Id1, T2.ID AS Id2, T1.DepartTime AS DepTime1, T1.Origin AS Origin1, T1.ArriveTime AS ArrTime1,
T1.Destination AS Dest1, T2.DepartTime AS DepTime2, T2.Destination AS Dest2, T2.ArriveTime AS ArrTime2,
T1.TicketCost + T2.TicketCost AS Cost
FROM Train AS T1, Train AS T2
WHERE T1.ID != T2.ID AND T1.Destination = T2.Origin AND T1.ArriveTime < T2.DepartTime
GO
/****** Object:  View [dbo].[TicketInfo]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TicketInfo]
AS
SELECT        dbo.Ticket.ID AS TicketID, dbo.Train.ID, dbo.Train.Origin, dbo.Train.Destination, dbo.Train.DepartTime, dbo.Train.ArriveTime, dbo.Train.MaxCapacity, dbo.Train.TicketCost, dbo.Ticket.UserTelNum
FROM            dbo.Ticket INNER JOIN
                         dbo.Train ON dbo.Ticket.TrainID = dbo.Train.ID
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Train] FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Train]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_User] FOREIGN KEY([UserTelNum])
REFERENCES [dbo].[Buyer] ([TelNum])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_User]
GO
/****** Object:  StoredProcedure [dbo].[NewTicket]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewTicket]
(
@UserTelNum nvarchar(11), @TrainID int
)
WITH EXECUTE AS 'dbo'
AS
BEGIN

INSERT INTO [Ticket](ID, UserTelNum, TrainID)
SELECT MAX(ID) + 1, @UserTelNum, @TrainID FROM [Ticket]

END
GO
/****** Object:  StoredProcedure [dbo].[NewTrainPrice]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewTrainPrice]
(
@TicketCost int, @TrainID int
)
WITH EXECUTE AS 'dbo'
AS
BEGIN
UPDATE Train
SET TicketCost = @TicketCost
WHERE ID = @TrainID
SELECT * FROM Train
END
GO
/****** Object:  StoredProcedure [dbo].[SearchIndirectTrains]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchIndirectTrains] AS
WITH NullTicket AS (
	SELECT TrainID, COUNT(*) AS IdCount FROM Ticket GROUP BY TrainID
),
	CountTicket AS (
	SELECT Train.ID, CASE WHEN NullTicket.IdCount IS NULL THEN 0 ELSE NullTicket.IdCount END IdCount
	FROM Train LEFT JOIN NullTicket ON Train.ID=NullTicket.TrainID
),
	FreeTrains AS(
	SELECT Train.* FROM Train, CountTicket
	WHERE Train.ID = CountTicket.ID AND Train.MaxCapacity > CountTicket.IdCount
)
SELECT 
T1.ID AS Id1, T2.ID AS Id2, T1.DepartTime AS DepTime1, T1.Origin AS Origin1, T1.ArriveTime AS ArrTime1,
T1.Destination AS Dest1, T2.DepartTime AS DepTime2, T2.Destination AS Dest2, T2.ArriveTime AS ArrTime2
FROM FreeTrains AS T1, FreeTrains AS T2
WHERE T1.ID != T2.ID AND T1.Destination = T2.Origin AND T1.ArriveTime < T2.DepartTime
GO
/****** Object:  StoredProcedure [dbo].[SearchTrains]    Script Date: 01.03.2022 4:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchTrains] AS
WITH NullTicket AS (
	SELECT TrainID, COUNT(*) AS IdCount FROM Ticket GROUP BY TrainID
),
	CountTicket AS (
	SELECT Train.ID, CASE WHEN NullTicket.IdCount IS NULL THEN 0 ELSE NullTicket.IdCount END IdCount
	FROM Train LEFT JOIN NullTicket ON Train.ID=NullTicket.TrainID
)
SELECT Train.* FROM Train, CountTicket
WHERE Train.ID = CountTicket.ID AND Train.MaxCapacity > CountTicket.IdCount
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "Ticket"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Train"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 136
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TicketInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TicketInfo'
GO
USE [master]
GO
ALTER DATABASE [TrainsDB] SET  READ_WRITE 
GO
