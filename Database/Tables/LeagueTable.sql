/****** Object:  Table [dbo].[LeagueTable]    Script Date: 28/04/2013 12:56:47 ******/
DROP TABLE [dbo].[LeagueTable]
GO

/****** Object:  Table [dbo].[LeagueTable]    Script Date: 28/04/2013 12:56:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LeagueTable](
	[Player] [smallint] NOT NULL,
	[Matchs] [smallint] NOT NULL,
	[Win] [smallint] NOT NULL,
	[Draw] [smallint] NOT NULL,
	[Lost] [smallint] NOT NULL,
	[GamesWon] [smallint] NOT NULL,
	[GamesLost] [smallint] NOT NULL,
	[GamesDiff]  AS ([GamesWon]-[GamesLost]),
	[Points]  AS ([Win]*(3)+[Draw]),
	[WinPercentage]  AS ([dbo].[WinPercentage]([Win],[Lost],[Draw])),
 CONSTRAINT [PK_LeagueTable] PRIMARY KEY CLUSTERED 
(
	[Player] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


