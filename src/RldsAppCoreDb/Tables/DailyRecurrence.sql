CREATE TABLE [dbo].[DailyRecurrence]
(
	[DailyRecurrenceId] [bigint] IDENTITY NOT NULL,
	[Time] TIME NOT NULL,
	
    [ts] ROWVERSION NOT NULL, 
    CONSTRAINT [PK_DailyRecurrenceId]
		PRIMARY KEY ([DailyRecurrenceId])
)