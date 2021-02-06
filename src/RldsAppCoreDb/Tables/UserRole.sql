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

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Junction table between users and roles',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'UserRole',
	@level2type = NULL, @level2name = NULL;
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'User identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'UserRole',
	@level2type = N'COLUMN', @level2name = N'UserId';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Role identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'UserRole',
	@level2type = N'COLUMN', @level2name = N'RoleId';
GO
