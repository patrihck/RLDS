CREATE TABLE [dbo].[TransactionState]
(
	[TransactionStateId] BIGINT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [ts] ROWVERSION NOT NULL, 
    [Ordinal] INT NULL
)
