/****** Object:  StoredProcedure [dbo].[DeleteGame]    Script Date: 29/04/2013 20:57:30 ******/
DROP PROCEDURE [dbo].[DeleteGame]
GO

/****** Object:  StoredProcedure [dbo].[DeleteGame]    Script Date: 29/04/2013 20:57:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteGame]
	@GameID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Games] WHERE Id = @GameID

	EXEC GenerateLeagueTable

END



GO


