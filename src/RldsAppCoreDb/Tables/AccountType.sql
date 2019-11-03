CREATE TABLE [dbo].[AccountType]
(
	[AccountTypeId] BIGINT NOT NULL PRIMARY KEY, 
    [UserId] BIGINT NULL,
		FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARBINARY(MAX) NULL, 
    [ts] ROWVERSION NOT NULL
)
