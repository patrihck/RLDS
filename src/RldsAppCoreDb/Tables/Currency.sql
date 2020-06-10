CREATE TABLE [dbo].[Currency]
(
	[CurrencyId] [bigint] IDENTITY NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Acronym] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[IsPrefix] [bit] NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_Currency]
		PRIMARY KEY ([CurrencyId]),
	CONSTRAINT [UQ_Currency_Acronym]
		UNIQUE ([Acronym])
);
GO
