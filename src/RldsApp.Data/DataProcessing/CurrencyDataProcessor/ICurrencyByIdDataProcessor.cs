using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.CurrencyDataProcessor
{
	public interface ICurrencyByIdDataProcessor
	{
		Currency GetCurrencyById(long currencyId);
	}
}
