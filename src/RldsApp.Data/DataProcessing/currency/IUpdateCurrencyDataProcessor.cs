using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.currency
{
	public interface IUpdateCurrencyDataProcessor
	{
		Currency UpdateName(long currencyId, string name);
		Currency UpdateSymbol(long currencyId, string symbol);
	}
}
