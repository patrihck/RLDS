CREATE TABLE [dbo].[RecurringTransactionMonthRule]
(
	[RecurringTransactionMonthRuleId] [bigint] IDENTITY NOT NULL,
	[RecurringTransactionId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 0,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[SelectedDay] [int] NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_RecurringTransactionMonthRule]
		PRIMARY KEY ([RecurringTransactionMonthRuleId]),
	CONSTRAINT [FK_RecurringTransactionMonthRule_RecurringTransaction]
		FOREIGN KEY ([RecurringTransactionId])
		REFERENCES [RecurringTransaction] ([RecurringTransactionId]),
);
GO
