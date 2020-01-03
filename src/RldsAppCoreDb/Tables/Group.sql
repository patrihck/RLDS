﻿CREATE TABLE [dbo].[Group]
(
    [GroupId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Info] NVARCHAR(128) NULL, 
    [Ordinal] INT NULL, 
    [ts] ROWVERSION NULL
)
