/****** Object:  Table [dbo].[Players]    Script Date: 28/04/2013 12:57:09 ******/
DROP TABLE [dbo].[Players]
GO

/****** Object:  Table [dbo].[Players]    Script Date: 28/04/2013 12:57:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Players](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Nickname] [varchar](40) NULL,
	[Email] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


