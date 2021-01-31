CREATE TABLE [dbo].[RecurringTransactionDayRule]
(
	[RecurringTransactionDayRuleId] [bigint] IDENTITY NOT NULL,
	[RecurringTransactionId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 0,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_RecurringTransactionDayRule]
		PRIMARY KEY ([RecurringTransactionDayRuleId]),
	CONSTRAINT [FK_RecurringTransactionDayRule_RecurringTransaction]
		FOREIGN KEY ([RecurringTransactionId])
		REFERENCES [RecurringTransaction] ([RecurringTransactionId]),
);
GO
