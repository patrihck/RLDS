CREATE TABLE [dbo].[UserRole]
(
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	CONSTRAINT [PK_UserRole]
		PRIMARY KEY ([UserId], [RoleId]),
	CONSTRAINT [FK_UserRole_User]
		FOREIGN KEY ([UserId])
		REFERENCES [User] ([UserId]),
	CONSTRAINT [FK_UserRole_Role]
		FOREIGN KEY ([RoleId])
		REFERENCES [Role] ([RoleId])
);
GO
