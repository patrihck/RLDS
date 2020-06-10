CREATE TABLE [dbo].[Group]
(
	[GroupId] [bigint] IDENTITY NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Info] [nvarchar](250) NOT NULL,
	[Ordinal] [int] NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_Group]
		PRIMARY KEY ([GroupId])
)
