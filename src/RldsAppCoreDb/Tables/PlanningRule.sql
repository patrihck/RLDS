CREATE TABLE [dbo].[PlanningRule]
(
	[PlanningRuleId] [bigint] IDENTITY NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[CurrencyId] [bigint] NOT NULL,
	[SenderId] [bigint] NOT NULL,
	[ReceiverId] [bigint] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Amount] [money] NOT NULL,
	[PeriodId] [bigint] NOT NULL,
	[ts] [rowversion] NOT NULL,
	[Group] VARCHAR(64) NULL, 
   
   CONSTRAINT [PK_PlanningRule]
		PRIMARY KEY ([PlanningRuleId]),
	
	CONSTRAINT [FK_PlanningRule_User]
		FOREIGN KEY ([UserId])
		REFERENCES [User] ([UserId]),

	CONSTRAINT [FK_PlanningRule_TransactionCategory]
		FOREIGN KEY ([CategoryId])
		REFERENCES [TransactionCategory] ([TransactionCategoryId]),

	CONSTRAINT [FK_PlanningRule_Currency]
		FOREIGN KEY ([CurrencyId])
		REFERENCES [Currency] ([CurrencyId]),

	CONSTRAINT [FK_PlanningRule_PeriodId]
		FOREIGN KEY ([PeriodId])
		REFERENCES [Period] ([PeriodId]),

	CONSTRAINT [FK_PlanningRule_AccountSender]
		FOREIGN KEY ([SenderId])
		REFERENCES [Account] ([AccountId]),

	CONSTRAINT [FK_PlanningRule_AccountReceiver]
		FOREIGN KEY ([ReceiverId])
		REFERENCES [Account] ([AccountId])
);
GO
