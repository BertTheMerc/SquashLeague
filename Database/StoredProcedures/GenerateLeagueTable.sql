/****** Object:  StoredProcedure [dbo].[GenerateLeagueTable]    Script Date: 29/04/2013 20:56:34 ******/
DROP PROCEDURE [dbo].[GenerateLeagueTable]
GO

/****** Object:  StoredProcedure [dbo].[GenerateLeagueTable]    Script Date: 29/04/2013 20:56:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Bert
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GenerateLeagueTable] 
AS
BEGIN
	TRUNCATE TABLE LeagueTable

	DECLARE @MaxPlayers smallint
	DECLARE @CurrentPlayer smallint

	SELECT @CurrentPlayer = 1
	SELECT @MaxPlayers = (SELECT MAX(ID) FROM Players)

	WHILE @CurrentPlayer <= @MaxPlayers
	BEGIN
		IF ((SELECT COUNT(1) FROM Players WHERE ID = @CurrentPlayer) > 0)
		BEGIN
			INSERT INTO LeagueTable (Player, Matchs, Win, Lost, Draw, GamesWon, GamesLost) VALUES
			(
			@CurrentPlayer,
			--MatchsWon
			(SELECT COUNT(1) FROM vLeagueResults WHERE Player1=@CurrentPlayer OR Player2=@CurrentPlayer),
			(SELECT COUNT(1) FROM vLeagueResults WHERE (Player1=@CurrentPlayer AND Player1Score > Player2Score) OR (Player2=@CurrentPlayer AND Player2Score > Player1Score)),
			(SELECT	COUNT(1) AS MatchsLost FROM vLeagueResults WHERE (Player1=@CurrentPlayer AND Player1Score < Player2Score) OR (Player2=@CurrentPlayer AND Player1Score > Player2Score)),
			(SELECT COUNT(1) AS MatchsDrawn FROM vLeagueResults WHERE (Player1=@CurrentPlayer AND Player1Score = Player2Score)),
			(
				(SELECT ISNULL(SUM(Player1Score), 0) From vLeagueResults WHERE Player1 = @CurrentPlayer) +
				(SELECT ISNULL(SUM(Player2Score), 0) From vLeagueResults WHERE Player2 = @CurrentPlayer)
			),
			(
				(SELECT ISNULL(SUM(Player2Score), 0) From vLeagueResults WHERE Player1 = @CurrentPlayer) +
				(SELECT ISNULL(SUM(Player1Score), 0) From vLeagueResults WHERE Player2 = @CurrentPlayer)
			)
			)			
		END

		SELECT @CurrentPlayer = @Currentplayer+1
	END
END


GO

