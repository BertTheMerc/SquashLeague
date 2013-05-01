/****** Object:  View [dbo].[vResults]    Script Date: 28/04/2013 12:58:01 ******/
DROP VIEW [dbo].[vResults]
GO
USE [dbc59d672f57bf48fdafa8a1a500dea947]
GO

/****** Object:  View [dbo].[vResults]    Script Date: 29/04/2013 20:54:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vResults]
AS
SELECT        
	dbo.Games.ID, 
	dbo.Games.Played, 
	dbo.Games.Player1Score, 
	dbo.Games.Player2Score, 
	dbo.Players.Name AS Player1Name, 
	Players_1.Name AS Player2Name, 
	dbo.Games.Player1, 
	dbo.Games.Player2,
	dbo.Games.GameType
FROM            
	dbo.Games 
	INNER JOIN dbo.Players ON dbo.Games.Player1 = dbo.Players.ID 
	INNER JOIN dbo.Players AS Players_1 ON dbo.Games.Player2 = Players_1.ID
GO

