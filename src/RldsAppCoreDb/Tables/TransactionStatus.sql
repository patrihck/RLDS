﻿CREATE TABLE [dbo].[TransactionStatus]
(
	[TransactionStatusId] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [ts] ROWVERSION NOT NULL, 
    [Ordinal] INT NULL
)
