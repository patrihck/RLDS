using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.currency
{
	public interface ICurrencyByNameDataProcessor
	{
		Currency GetCurrencyByName(string name);
	}
}
