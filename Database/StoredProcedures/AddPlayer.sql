/****** Object:  StoredProcedure [dbo].[AddPlayer]    Script Date: 28/04/2013 12:58:20 ******/
DROP PROCEDURE [dbo].[AddPlayer]
GO

/****** Object:  StoredProcedure [dbo].[AddPlayer]    Script Date: 29/04/2013 20:55:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPlayer]
	@Name varchar(20),
	@Nickname varchar(40),
	@Email varchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Players]
           ([Name]
           ,[Nickname]
           ,[Email])
     VALUES
           (@Name,
            @Nickname,
            @Email)
END

GO