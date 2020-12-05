CREATE TABLE [dbo].[Monthly]
(
	[MonthlyId] INT NOT NULL PRIMARY KEY,	
	[Month] [int] NOT NULL,
	
	CONSTRAINT [PK_MonthlyId]
		PRIMARY KEY ([MonthlyId])
)