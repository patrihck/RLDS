CREATE TABLE [dbo].[TransactionStatus]
(
	[TransactionStatusId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Ordinal] INT NOT NULL,
	CONSTRAINT [PK_TransactionStatus]
		PRIMARY KEY ([TransactionStatusId])
);
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'System dictionary of transaction statuses',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionStatus',
	@level2type = NULL, @level2name = NULL;
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Record identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionStatus',
	@level2type = N'COLUMN', @level2name = N'TransactionStatusId';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Status name',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionStatus',
	@level2type = N'COLUMN', @level2name = N'Name';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Ordinal number',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'TransactionStatus',
	@level2type = N'COLUMN', @level2name = N'Ordinal';
GO
