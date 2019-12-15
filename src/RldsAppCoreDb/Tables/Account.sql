CREATE TABLE [dbo].[Account]
(
	[AccountId] BIGINT NOT NULL PRIMARY KEY, 
	[UserId] BIGINT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
    [CurrencyId] BIGINT NOT NULL, 
	 FOREIGN KEY (CurrencyId) REFERENCES dbo.[Currency] (CurrencyId),
	[GroupId] INT NOT NULL, 
	    FOREIGN KEY (GroupId) REFERENCES dbo.[Group] (GroupId),
	[AccountTypeId] BIGINT NOT NULL, 
		FOREIGN KEY (AccountTypeId) REFERENCES dbo.[AccountType] (AccountTypeId),
    [StartAmount] MONEY NOT NULL, 
    [ts] ROWVERSION NULL
)
