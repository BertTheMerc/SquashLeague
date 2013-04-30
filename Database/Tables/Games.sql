/****** Object:  Table [dbo].[Games]    Script Date: 28/04/2013 12:54:44 ******/
DROP TABLE [dbo].[Games]
GO

/****** Object:  Table [dbo].[Games]    Script Date: 28/04/2013 12:54:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Games](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Played] [datetime] NOT NULL,
	[Player1] [smallint] NOT NULL,
	[Player2] [smallint] NOT NULL,
	[Player1Score] [smallint] NOT NULL,
	[Player2Score] [smallint] NOT NULL,
	[GameType] [CHAR](1) NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


