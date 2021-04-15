CREATE TABLE [dbo].[RecurringRule]
(
	[RecurringRuleId] [bigint] IDENTITY NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SenderId] [bigint] NOT NULL,
	[ReceiverId] [bigint] NOT NULL, 
	[CategoryId] [bigint] NOT NULL,
	[CurrencyId] [bigint] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Amount] [money] NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_RecurringRule]
		PRIMARY KEY ([RecurringRuleId]),
	CONSTRAINT [FK_RecurringRule_User]
		FOREIGN KEY ([UserId])
		REFERENCES [User] ([UserId]),
	CONSTRAINT [FK_RecurringRule_Account_Sender]
		FOREIGN KEY ([SenderId])
		REFERENCES [Account] ([AccountId]),
	CONSTRAINT [FK_RecurringRule_Account_Receiver]
		FOREIGN KEY ([ReceiverId])
		REFERENCES [Account] ([AccountId]), 
	CONSTRAINT [FK_RecurringRule_TransactionCategory]
		FOREIGN KEY ([CategoryId])
		REFERENCES [TransactionCategory] ([TransactionCategoryId]),
	CONSTRAINT [FK_RecurringRule_Currency]
		FOREIGN KEY ([CurrencyId])
		REFERENCES [Currency] ([CurrencyId])
);
GO
