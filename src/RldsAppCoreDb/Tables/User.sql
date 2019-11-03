CREATE TABLE [dbo].[User]
(
	[UserId] BIGINT IDENTITY(1,1) NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY ([UserId]),
    [Login] NVARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [Firstname] VARCHAR(50) NOT NULL, 
    [Lastname] VARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [ts] ROWVERSION NOT NULL
)
