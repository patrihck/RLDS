CREATE TABLE [dbo].[RecurringTransactionWeekRule]
(
	[RecurringTransactionWeekRuleId] [bigint] IDENTITY NOT NULL,
	[RecurringTransactionId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 0,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsMonday] [bit] NOT NULL DEFAULT 0,
	[IsTuesday] [bit] NOT NULL DEFAULT 0,
	[IsWednesday] [bit] NOT NULL DEFAULT 0,
	[IsThursday] [bit] NOT NULL DEFAULT 0,
	[IsFriday] [bit] NOT NULL DEFAULT 0,
	[IsSaturday] [bit] NOT NULL DEFAULT 0,
	[IsSunday] [bit] NOT NULL DEFAULT 0,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_RecurringTransactionWeekRule]
		PRIMARY KEY ([RecurringTransactionWeekRuleId]),
	CONSTRAINT [FK_RecurringTransactionWeekRule_RecurringTransaction]
		FOREIGN KEY ([RecurringTransactionId])
		REFERENCES [RecurringTransaction] ([RecurringTransactionId]),
);
GO