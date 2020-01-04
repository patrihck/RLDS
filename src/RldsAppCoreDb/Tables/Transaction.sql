CREATE TABLE [dbo].[Transaction]
(
	[TransactionId] BIGINT NOT NULL PRIMARY KEY, 
    [UserId] BIGINT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
    [SourceAccountId] BIGINT NULL, 
    FOREIGN KEY ([SourceAccountId]) REFERENCES dbo.[Account] (AccountId),
    [TargetAccountId] BIGINT NULL, 
	FOREIGN KEY ([TargetAccountId]) REFERENCES dbo.[Account] (AccountId),
    [TransactionStatusId] BIGINT NOT NULL, 
	FOREIGN KEY ([TransactionStatusId]) REFERENCES dbo.[TransactionStatus] (TransactionStatusId),
    [CategoryId] BIGINT NULL,
    FOREIGN KEY (CategoryId) REFERENCES dbo.[Category] (CategoryId),
	[Type] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Amount] MONEY NOT NULL, 
	[ts] ROWVERSION NOT NULL, 
)