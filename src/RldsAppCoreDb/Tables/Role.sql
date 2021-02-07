CREATE TABLE [dbo].[Role]
(
	[RoleId] [bigint] IDENTITY NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_Role]
		PRIMARY KEY ([RoleId])
);
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'User dictionary of user roles',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'Role',
	@level2type = NULL, @level2name = NULL;
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Record identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'Role',
	@level2type = N'COLUMN', @level2name = N'RoleId';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Role name',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'Role',
	@level2type = N'COLUMN', @level2name = N'RoleName';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Concurrency token',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'Role',
	@level2type = N'COLUMN', @level2name = N'ts';
GO
