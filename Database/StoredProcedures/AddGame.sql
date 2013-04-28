/****** Object:  StoredProcedure [dbo].[AddGame]    Script Date: 28/04/2013 12:58:20 ******/
DROP PROCEDURE [dbo].[AddGame]
GO

/****** Object:  StoredProcedure [dbo].[AddGame]    Script Date: 28/04/2013 12:58:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddGame]
	@DateOfGame datetime,
	@Player1 int,
	@Player2 int,
	@Player1Score smallint,
	@Player2Score smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Games]
           ([Played]
           ,[Player1]
           ,[Player2]
           ,[Player1Score]
           ,[Player2Score])
     VALUES
           (@DateOfGame,
            @Player1,
            @Player2, 
            @Player1Score,
            @Player2Score)


	EXEC GenerateLeagueTable

END



GO


