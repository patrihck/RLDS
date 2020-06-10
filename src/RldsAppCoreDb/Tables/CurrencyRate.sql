CREATE TABLE [dbo].[CurrencyRate]
(
	[SourceCurrencyId] [bigint] NOT NULL,
	[TargetCurrencyId] [bigint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Rate] [decimal](18,9) NOT NULL,
	[ts] [rowversion] NOT NULL,
	CONSTRAINT [PK_CurrencyRate]
		PRIMARY KEY ([SourceCurrencyId], [TargetCurrencyId], [Date]),
	CONSTRAINT [FK_CurrencyRate_SourceCurrency]
		FOREIGN KEY ([SourceCurrencyId])
		REFERENCES [Currency] ([CurrencyId]),
	CONSTRAINT [FK_CurrencyRate_TargetCurrency]
		FOREIGN KEY ([TargetCurrencyId])
		REFERENCES [Currency] ([CurrencyId])
);
GO
