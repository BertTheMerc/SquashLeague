/****** Object:  UserDefinedFunction [dbo].[WinPercentage]    Script Date: 28/04/2013 12:59:36 ******/
DROP FUNCTION [dbo].[WinPercentage]
GO

/****** Object:  UserDefinedFunction [dbo].[WinPercentage]    Script Date: 29/04/2013 20:53:27 ******/
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
RETURNS INT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result INT
	SELECT @Result = 0
	
	DECLARE @Matchs smallint
	SELECT @Matchs = @Won + @Lost + @Draw

	IF @Matchs > 0
	(
		SELECT @Result = ROUND(100.0/@Matchs * @Won, 0)
	)

	RETURN @Result

END


GO

