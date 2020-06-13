using System;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.CurrencyRateDataProcessor
{
	public interface ICurrencyRateByDateDataProcessor
	{
		CurrencyRate GetCurrencyRateByDate(long sourceCurrencyId, long targetCurrencyId, DateTime date);
	}
}
