CREATE TABLE [dbo].[UserAccount]
(
	[UserId] BIGINT NOT NULL, 
    [AccountId] BIGINT NOT NULL, 
    [ts] ROWVERSION NOT NULL,
	PRIMARY KEY (UserId, AccountId),
	CONSTRAINT FK_AccountUser
      FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
	CONSTRAINT FK_Account
      FOREIGN KEY (AccountId) REFERENCES dbo.[Account] (AccountId)
)
