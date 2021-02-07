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

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Currency exchange rate values',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'CurrencyRate',
	@level2type = NULL, @level2name = NULL;
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Source currency identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'CurrencyRate',
	@level2type = N'COLUMN', @level2name = N'SourceCurrencyId';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Target currency identifier',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'CurrencyRate',
	@level2type = N'COLUMN', @level2name = N'TargetCurrencyId';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'The date of validity of exchange rate',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'CurrencyRate',
	@level2type = N'COLUMN', @level2name = N'Date';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Currency exchange rate',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'CurrencyRate',
	@level2type = N'COLUMN', @level2name = N'Rate';
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'Concurrency token',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'TABLE', @level1name = N'CurrencyRate',
	@level2type = N'COLUMN', @level2name = N'ts';
GO
