﻿CREATE TABLE [dbo].[Role]
(
	[RoleId] BIGINT IDENTITY(1,1)  NOT NULL PRIMARY KEY, 
    [RoleName] VARCHAR(50) NOT NULL, 
    [ts] ROWVERSION NOT NULL
)
