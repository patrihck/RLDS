CREATE TABLE [dbo].[TransactionCategory]
(
	[TransactionCategoryId] [bigint] IDENTITY NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[RootId] [bigint] NULL,
	[ts] ROWVERSION NOT NULL, 
	CONSTRAINT [PK_TransactionCategory]
		PRIMARY KEY ([TransactionCategoryId]),
	CONSTRAINT [FK_TransactionCategory_TransactionCategory_Root]
		FOREIGN KEY ([RootId])
		REFERENCES [TransactionCategory] ([TransactionCategoryId])
);
GO
