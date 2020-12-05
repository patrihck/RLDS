CREATE TABLE [dbo].[Daily]
(
	[DailyId] [bigint] NOT NULL PRIMARY KEY,
	[Hour] [int] NOT NULL,
	
	CONSTRAINT [PK_DailyId]
		PRIMARY KEY ([DailyId])
)