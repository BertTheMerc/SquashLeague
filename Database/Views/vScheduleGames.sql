/****** Object:  View [dbo].[vScheduleGames]    Script Date: 29/04/2013 21:49:36 ******/
DROP VIEW [dbo].[vScheduleGames]
GO

/****** Object:  View [dbo].[vScheduleGames]    Script Date: 29/04/2013 21:49:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vScheduleGames]
AS
SELECT        
	dbo.ScheduleGames.ID, 
	dbo.ScheduleGames.ScheduledDate, 
	dbo.Players.Name AS Player1Name, 
	Players_1.Name AS Player2Name, 
	dbo.ScheduleGames.Player1, 
	dbo.ScheduleGames.Player2
FROM            
	dbo.ScheduleGames 
	INNER JOIN dbo.Players ON dbo.ScheduleGames.Player1 = dbo.Players.ID 
	INNER JOIN dbo.Players AS Players_1 ON dbo.ScheduleGames.Player2 = Players_1.ID


GO


