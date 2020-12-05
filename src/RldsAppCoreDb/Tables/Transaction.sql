CREATE TABLE [dbo].[Transaction]
(
	[TransactionId] [bigint] IDENTITY NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SenderId] [bigint] NOT NULL,
	[ReceiverId] [bigint] NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[StatusId] [bigint] NOT NULL,
	[CurrencyId] [bigint] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Amount] [money] NOT NULL,
	[ts] [rowversion] NOT NULL,
	[Group] VARCHAR(64) NULL, 

    CONSTRAINT [PK_Transaction]
		PRIMARY KEY ([TransactionId]),
	CONSTRAINT [FK_Transaction_User]
		FOREIGN KEY ([UserId])
		REFERENCES [User] ([UserId]),
	CONSTRAINT [FK_Transaction_AccountSender]
		FOREIGN KEY ([SenderId])
		REFERENCES [Account] ([AccountId]),
	CONSTRAINT [FK_Transaction_AccountReceiver]
		FOREIGN KEY ([ReceiverId])
		REFERENCES [Account] ([AccountId]),
	CONSTRAINT [FK_Transaction_TransactionType]
		FOREIGN KEY ([TypeId])
		REFERENCES [TransactionType] ([TransactionTypeId]),
	CONSTRAINT [FK_Transaction_TransactionCategory]
		FOREIGN KEY ([CategoryId])
		REFERENCES [TransactionCategory] ([TransactionCategoryId]),
	CONSTRAINT [FK_Transaction_TransactionStatus]
		FOREIGN KEY ([StatusId])
		REFERENCES [TransactionStatus] ([TransactionStatusId]),
	CONSTRAINT [FK_Transaction_Currency]
		FOREIGN KEY ([CurrencyId])
		REFERENCES [Currency] ([CurrencyId])
);
GO
