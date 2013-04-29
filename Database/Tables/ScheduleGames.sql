/****** Object:  Table [dbo].[Games]    Script Date: 28/04/2013 12:54:44 ******/
DROP TABLE [dbo].[ScheduleGames]
GO

/****** Object:  Table [dbo].[Games]    Script Date: 28/04/2013 12:54:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ScheduleGames](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduledDate] [datetime] NOT NULL,
	[Player1] [smallint] NOT NULL,
	[Player2] [smallint] NOT NULL,
 CONSTRAINT [PK_ScheduleGames] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


