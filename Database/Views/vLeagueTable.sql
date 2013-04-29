/****** Object:  View [dbo].[vLeagueTable]    Script Date: 28/04/2013 12:57:29 ******/
DROP VIEW [dbo].[vLeagueTable]
GO
USE [dbc59d672f57bf48fdafa8a1a500dea947]
GO

/****** Object:  View [dbo].[vLeagueTable]    Script Date: 29/04/2013 20:54:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vLeagueTable]
AS
SELECT TOP 100 PERCENT
	dbo.Players.Name, 
	dbo.LeagueTable.Matchs, 
	dbo.LeagueTable.Win, 
	dbo.LeagueTable.Draw, 
	dbo.LeagueTable.Lost, 
    dbo.LeagueTable.GamesWon, 
	dbo.LeagueTable.GamesLost, 
	dbo.LeagueTable.GamesDiff, 
	dbo.LeagueTable.Points, 
	dbo.LeagueTable.WinPercentage
FROM
	dbo.Players 
	INNER JOIN dbo.LeagueTable ON dbo.Players.ID = dbo.LeagueTable.Player
ORDER BY 
	dbo.LeagueTable.Points DESC, 
	dbo.LeagueTable.GamesDiff DESC


GO

