CREATE TABLE [dbo].[Account]
(
	[AccountId] [bigint] IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL, 
	[UserId] BIGINT NOT NULL, 
	[CurrencyId] BIGINT NOT NULL, 
	[GroupId] BIGINT NULL, 
	[StartAmount] MONEY NOT NULL, 
	[ts] ROWVERSION NOT NULL, 
	CONSTRAINT [PK_Account]
		PRIMARY KEY ([AccountId]),
	CONSTRAINT [FK_Account_User]
		FOREIGN KEY ([UserId])
		REFERENCES [User] ([UserId]),
	CONSTRAINT [FK_Account_Currency]
		FOREIGN KEY ([CurrencyId])
		REFERENCES [Currency] ([CurrencyId]),
	CONSTRAINT [FK_Account_Group]
		FOREIGN KEY ([GroupId])
		REFERENCES [Group] ([GroupId])
);
GO
