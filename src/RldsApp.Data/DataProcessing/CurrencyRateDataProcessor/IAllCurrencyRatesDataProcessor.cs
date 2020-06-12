using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.CurrencyRateDataProcessor
{
	public interface IAllCurrencyRatesDataProcessor
	{
		QueryResult<CurrencyRate> GetCurrencyRates(PagedDataRequest requestInfo, long sourceCurrencyId, long targetCurrencyId);
	}
}
