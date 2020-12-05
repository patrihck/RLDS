CREATE TABLE [dbo].[TransactionRule]
(
	[TransactionRuleId] [bigint] IDENTITY NOT NULL,
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
   
   CONSTRAINT [PK_TransactionRule]
		PRIMARY KEY ([TransactionRuleId]),
	
	CONSTRAINT [FK_TransactionRule_User]
		FOREIGN KEY ([UserId])
		REFERENCES [User] ([UserId]),

	CONSTRAINT [FK_TransactionRule_TransactionCategory]
		FOREIGN KEY ([CategoryId])
		REFERENCES [TransactionCategory] ([TransactionCategoryId]),

	CONSTRAINT [FK_TransactionRule_Currency]
		FOREIGN KEY ([CurrencyId])
		REFERENCES [Currency] ([CurrencyId]),

	CONSTRAINT [FK_TransactionRule_TransactionRuleId]
		FOREIGN KEY ([TransactionRuleId])
		REFERENCES [TransactionRule] ([TransactionRuleId]),

	CONSTRAINT [FK_TransactionRule_AccountSender]
		FOREIGN KEY ([SenderId])
		REFERENCES [Account] ([AccountId]),

	CONSTRAINT [FK_TransactionRule_AccountReceiver]
		FOREIGN KEY ([ReceiverId])
		REFERENCES [Account] ([AccountId])
);
GO
