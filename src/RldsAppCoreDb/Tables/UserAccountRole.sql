CREATE TABLE [dbo].[UserAccountRole]
(	
	[UserId] BIGINT NOT NULL, 
    [RoleId] BIGINT NOT NULL, 
	[AccountId]	BIGINT NOT NULL,
	PRIMARY KEY (UserId, RoleId,AccountId),
	[ts] ROWVERSION NOT NULL,
	CONSTRAINT FK_UserId 
      FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
	CONSTRAINT FK_RoleId 
      FOREIGN KEY (RoleId) REFERENCES dbo.[Role] (RoleId),
	CONSTRAINT FK_AccountId
      FOREIGN KEY (AccountId) REFERENCES dbo.[Account] (AccountId),
)
