/****** Object:  StoredProcedure [dbo].[UpdatePlayer]    Script Date: 29/04/2013 20:58:06 ******/
DROP PROCEDURE [dbo].[UpdatePlayer]
GO

/****** Object:  StoredProcedure [dbo].[UpdatePlayer]    Script Date: 29/04/2013 20:58:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdatePlayer]
	@ID int,
	@Name varchar(20),
	@Nickname varchar(40),
	@Email varchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE	
		[dbo].[Players]
	SET [Name] = @Name,
		[Nickname] = @Nickname,
		[Email] = @Email
	WHERE ID = @ID

END



GO


