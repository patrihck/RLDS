using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyRateMaintenanceProcessor
{
	public interface IAddCurrencyRateMaintenanceProcessor
	{
		CurrencyRate AddCurrencyRate(NewCurrencyRate newCurrencyRate);
	}
}
