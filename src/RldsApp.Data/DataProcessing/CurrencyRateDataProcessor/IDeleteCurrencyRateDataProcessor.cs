using System;

namespace RldsApp.Data.DataProcessing.CurrencyRateDataProcessor
{
	public interface IDeleteCurrencyRateDataProcessor
	{
		bool DeleteCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date);
	}
}
