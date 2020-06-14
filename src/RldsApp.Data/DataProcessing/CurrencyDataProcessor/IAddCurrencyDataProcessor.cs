using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.CurrencyDataProcessor
{
	public interface IAddCurrencyDataProcessor
	{
		void AddCurrency(Currency currency);
	}
}
