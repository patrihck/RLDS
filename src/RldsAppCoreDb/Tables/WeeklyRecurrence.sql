CREATE TABLE [dbo].[WeeklyRecurrence]
(
	[WeeklyRecurrenceId] [bigint] IDENTITY NOT NULL,
	[Monday] BIT NOT NULL,
	
	[Tuesday] BIT NOT NULL, 
    [Wednesday] BIT NOT NULL, 
    [Thursday] BIT NOT NULL, 
    [Friday] BIT NOT NULL, 
    [Saturday] BIT NOT NULL, 
    [Sunday] BIT NOT NULL, 
    [ts] ROWVERSION NOT NULL, 
    CONSTRAINT [PK_WeeklyRecurrenceId]
		PRIMARY KEY ([WeeklyRecurrenceId])
)