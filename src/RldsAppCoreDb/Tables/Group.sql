CREATE TABLE [dbo].[Group]
(
	[GroupId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Info] NVARCHAR(128) NULL, 
    [Ordinal] NVARCHAR(128) NULL, 
    [ts] NVARCHAR(10) NULL
)
