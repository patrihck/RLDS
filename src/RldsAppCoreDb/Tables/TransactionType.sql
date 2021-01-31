CREATE TABLE [dbo].[TransactionType]
(
	[TransactionTypeId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_TransactionType]
		PRIMARY KEY ([TransactionTypeId])
);
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'System dictionary of transaction types',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionType',
	@level2type = NULL, @level2name = NULL;
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Record identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionType',
	@level2type = N'COLUMN', @level2name = N'TransactionTypeId';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Transaction type name',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionType',
	@level2type = N'COLUMN', @level2name = N'Name';
GO
