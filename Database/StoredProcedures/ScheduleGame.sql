/****** Object:  StoredProcedure [dbo].[ScheduleGame]    Script Date: 28/04/2013 12:58:20 ******/
DROP PROCEDURE [dbo].[ScheduleGame]
GO

/****** Object:  StoredProcedure [dbo].[ScheduleGame]    Script Date: 29/04/2013 20:55:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ScheduleGame]
	@DateOfGame datetime,
	@Player1 int,
	@Player2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[ScheduleGames]
           ([ScheduledDate]
           ,[Player1]
           ,[Player2]
           )
     VALUES
           (@DateOfGame,
            @Player1,
            @Player2)

END

GO