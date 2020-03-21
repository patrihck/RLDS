using RldsApp.Data.Entities;
using System.Collections.Generic;

namespace RldsApp.Data.DataProcessing.currency
{
	public interface IAllCurrenciesDataProcessor
	{
		List<Currency> GetCurrencies();
	}
}
