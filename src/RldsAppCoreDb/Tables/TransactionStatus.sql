CREATE TABLE [dbo].[TransactionStatus]
(
	[TransactionStatusId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Ordinal] INT NOT NULL,
	CONSTRAINT [PK_TransactionStatus]
		PRIMARY KEY ([TransactionStatusId])
);
GO
