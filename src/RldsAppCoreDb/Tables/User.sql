CREATE TABLE [dbo].[User]
(
	[UserId] [bigint] IDENTITY NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_User]
		PRIMARY KEY ([UserId])
);
GO
