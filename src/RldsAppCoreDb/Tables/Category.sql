CREATE TABLE [dbo].[Category]
(
	[CategoryId] BIGINT NOT NULL PRIMARY KEY, 
	[UserId] BIGINT NOT NULL,
		FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NULL, 
	[ts] ROWVERSION NOT NULL
)
