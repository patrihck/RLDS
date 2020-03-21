using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.currency
{
	public interface IAddCurrencyDataProcessor
	{
		void AddCurrency(Currency currency);
	}
}
