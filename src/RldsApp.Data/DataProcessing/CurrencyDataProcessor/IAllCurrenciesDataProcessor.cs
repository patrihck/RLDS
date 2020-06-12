using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.CurrencyDataProcessor
{
	public interface IAllCurrenciesDataProcessor
	{
		QueryResult<Currency> GetCurrencies(PagedDataRequest requestInfo);
	}
}
