CREATE TABLE [dbo].[RecurringTransaction]
(
	[RecurringTransactionId] [bigint] IDENTITY NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SenderId] [bigint] NOT NULL,
	[ReceiverId] [bigint] NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[CurrencyId] [bigint] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Amount] [money] NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_RecurringTransaction]
		PRIMARY KEY ([RecurringTransactionId]),
	CONSTRAINT [FK_RecurringTransaction_User]
		FOREIGN KEY ([UserId])
		REFERENCES [User] ([UserId]),
	CONSTRAINT [FK_RecurringTransaction_Account_Sender]
		FOREIGN KEY ([SenderId])
		REFERENCES [Account] ([AccountId]),
	CONSTRAINT [FK_RecurringTransaction_Account_Receiver]
		FOREIGN KEY ([ReceiverId])
		REFERENCES [Account] ([AccountId]),
	CONSTRAINT [FK_RecurringTransaction_TransactionType]
		FOREIGN KEY ([TypeId])
		REFERENCES [TransactionType] ([TransactionTypeId]),
	CONSTRAINT [FK_RecurringTransaction_TransactionCategory]
		FOREIGN KEY ([CategoryId])
		REFERENCES [TransactionCategory] ([TransactionCategoryId]),
	CONSTRAINT [FK_RecurringTransaction_Currency]
		FOREIGN KEY ([CurrencyId])
		REFERENCES [Currency] ([CurrencyId])
);
GO
