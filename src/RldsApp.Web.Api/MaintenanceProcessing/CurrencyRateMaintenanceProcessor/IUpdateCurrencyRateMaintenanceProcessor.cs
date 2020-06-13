using System;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyRateMaintenanceProcessor
{
	public interface IUpdateCurrencyRateMaintenanceProcessor
	{
		CurrencyRate UpdateCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date, object currencyRateFragment);
	}
}
