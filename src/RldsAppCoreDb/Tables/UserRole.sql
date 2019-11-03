CREATE TABLE [dbo].[UserRole]
(
	[UserId] BIGINT NOT NULL, 
    [RoleId] BIGINT NOT NULL, 
    [ts] ROWVERSION NOT NULL,
	PRIMARY KEY (UserId, RoleId),
	CONSTRAINT FK_User 
      FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
	CONSTRAINT FK_Role 
      FOREIGN KEY (RoleId) REFERENCES dbo.[Role] (RoleId)
)
