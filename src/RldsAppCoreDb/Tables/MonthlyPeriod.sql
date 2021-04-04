CREATE TABLE [dbo].[RecurringTransactionMonthRule]
(
	[MonthlyPeriodId] [bigint] IDENTITY NOT NULL,
	[RecurringRuleId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 0,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[SelectedDay] [int] NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_RecurringTransactionMonthRule]
		PRIMARY KEY ([MonthlyPeriodId]),
	CONSTRAINT [FK_RecurringTransactionMonthRule_RecurringTransaction]
		FOREIGN KEY ([RecurringRuleId])
		REFERENCES [RecurringTransaction] ([RecurringRuleId]),
);
GO
