CREATE TABLE [dbo].[Weekly]
(
	[WeeklyId] INT NOT NULL PRIMARY KEY,
	[Day] [int] NOT NULL,
	
	CONSTRAINT [PK_WeeklyId]
		PRIMARY KEY ([WeeklyId])
)