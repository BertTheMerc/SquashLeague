USE [dbc59d672f57bf48fdafa8a1a500dea947]
GO

/****** Object:  UserDefinedFunction [dbo].[WinPercentage]    Script Date: 28/04/2013 12:59:36 ******/
DROP FUNCTION [dbo].[WinPercentage]
GO

/****** Object:  UserDefinedFunction [dbo].[WinPercentage]    Script Date: 28/04/2013 12:59:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[WinPercentage] 
(
	-- Add the parameters for the function here
	@Won smallint,
	@Lost smallint,
	@Draw smallint
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result float
	SELECT @Result = 0

	DECLARE @Matchs smallint
	SELECT @Matchs = @Won + @Lost + @Draw

	IF @Matchs > 0
	(
		SELECT @Result = 100/@Matchs * @Won
	)
	
	RETURN @Result

END

GO


