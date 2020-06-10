CREATE TABLE [dbo].[TransactionType]
(
	[TransactionTypeId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_TransactionType]
		PRIMARY KEY ([TransactionTypeId])
);
GO
