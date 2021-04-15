CREATE TABLE [dbo].[RecurringTransactionDayRule]
(
	[DailyPeriodId] [bigint] IDENTITY NOT NULL,
	[RecurringRuleId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 0,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_RecurringTransactionDayRule]
		PRIMARY KEY ([DailyPeriodId]),
	CONSTRAINT [FK_RecurringTransactionDayRule_RecurringTransaction]
		FOREIGN KEY ([RecurringRuleId])
		REFERENCES [RecurringRule] ([RecurringRuleId]),
);
GO
