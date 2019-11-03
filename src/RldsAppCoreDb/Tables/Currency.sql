CREATE TABLE [dbo].[Currency]
(
	[CurrencyId] BIGINT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Symbol] VARCHAR(50) NOT NULL, 
    [ts] ROWVERSION NOT NULL
)
