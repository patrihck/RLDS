using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.currency
{
	public interface ICurrencyByIdDataProcessor
	{
		Currency GetCurrencyById(long currencyId);
	}
}
