CREATE TABLE [dbo].[Role]
(
	[RoleId] [bigint] IDENTITY NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_Role]
		PRIMARY KEY ([RoleId])
);
GO
