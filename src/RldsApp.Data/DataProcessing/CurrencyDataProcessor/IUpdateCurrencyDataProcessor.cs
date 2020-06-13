using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.CurrencyDataProcessor
{
	public interface IUpdateCurrencyDataProcessor
	{
		Currency UpdateCurrency(long currencyId, PropertyValueMapType updatedPropertyValueMap);
	}
}
