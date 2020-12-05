CREATE TABLE [dbo].[Recurrence]
(
	[RecurrenceId] [bigint] IDENTITY NOT NULL,
	[ts] [rowversion] NOT NULL,
   
   CONSTRAINT [PK_RecurrenceId]
		PRIMARY KEY ([RecurrenceId])
);
GO
