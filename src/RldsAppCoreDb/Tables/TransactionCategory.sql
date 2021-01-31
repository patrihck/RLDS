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

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'User dictionary of transaction categories',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionCategory',
	@level2type = NULL, @level2name = NULL;
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Record identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionCategory',
	@level2type = N'COLUMN', @level2name = N'TransactionCategoryId';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Transaction category name',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionCategory',
	@level2type = N'COLUMN', @level2name = N'Name';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Concurrency token',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionCategory',
	@level2type = N'COLUMN', @level2name = 'RootId';
GO
