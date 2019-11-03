CREATE TABLE [dbo].[Account]
(
	[AccountId] BIGINT NOT NULL PRIMARY KEY, 
	[UserId] BIGINT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
    [CurrencyId] BIGINT NOT NULL, 
	    FOREIGN KEY (CurrencyId) REFERENCES dbo.[Currency] (CurrencyId),
	[AccountTypeId] BIGINT NOT NULL, 
		FOREIGN KEY (AccountTypeId) REFERENCES dbo.[AccountType] (AccountTypeId),
    [Amount] MONEY NOT NULL, 
    [ts] ROWVERSION NULL
)
