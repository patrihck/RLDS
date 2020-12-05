CREATE TABLE [dbo].[Period]
(
	[PeriodId] [bigint] IDENTITY NOT NULL,
	[ts] [rowversion] NOT NULL,
	[Group] VARCHAR(64) NULL, 
   
   CONSTRAINT [PK_Period]
		PRIMARY KEY ([PeriodId])
);
GO
