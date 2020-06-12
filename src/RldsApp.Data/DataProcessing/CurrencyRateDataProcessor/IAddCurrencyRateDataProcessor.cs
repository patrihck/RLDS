using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.CurrencyRateDataProcessor
{
	public interface IAddCurrencyRateDataProcessor
	{
		void AddCurrencyRate(CurrencyRate currencyRate);
	}
}
