using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.CurrencyDataProcessor
{
	public interface ICurrencyByAcronymDataProcessor
	{
		Currency GetCurrencyByAcronym(string acronym);
	}
}
