/****** Object:  StoredProcedure [dbo].[ScheduleGame]    Script Date: 29/04/2013 22:33:51 ******/
DROP PROCEDURE [dbo].[EditScheduleGame]
GO

/****** Object:  StoredProcedure [dbo].[ScheduleGame]    Script Date: 29/04/2013 22:33:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditScheduleGame]
	@Id int,
	@DateOfGame datetime,
	@Player1 int,
	@Player2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[ScheduleGames]
	SET
       [ScheduledDate] = @DateOfGame,
       [Player1] = @Player1,
       [Player2] = @Player2
	WHERE
		ID = @ID
END


GO


