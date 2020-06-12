using System;
using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.CurrencyRateDataProcessor
{
	public interface IUpdateCurrencyRateDataProcessor
	{
		CurrencyRate UpdateCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date, PropertyValueMapType updatedPropertyValueMap);
	}
}
