using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.currency
{
	public interface IAllCurrenciesDataProcessor
	{
		QueryResult<Currency> GetCurrencies(PagedDataRequest requestInfo);
	}
}
