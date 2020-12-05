CREATE TABLE [dbo].[AnnualRecurrence]
(
	[AnnualRecurrenceId] [bigint] IDENTITY NOT NULL,	
	[January] BIT NOT NULL,
	
	[February] BIT NOT NULL, 
    [March] BIT NOT NULL, 
    [April] BIT NOT NULL, 
    [May] BIT NOT NULL, 
    [June] BIT NOT NULL, 
    [July] BIT NOT NULL, 
    [August] BIT NOT NULL, 
    [September] BIT NOT NULL, 
    [October] BIT NOT NULL, 
    [November] BIT NOT NULL, 
    [December] BIT NOT NULL, 
    [ts] ROWVERSION NOT NULL, 
    CONSTRAINT [PK_AnnualRecurrenceId]
		PRIMARY KEY ([AnnualRecurrenceId])
)