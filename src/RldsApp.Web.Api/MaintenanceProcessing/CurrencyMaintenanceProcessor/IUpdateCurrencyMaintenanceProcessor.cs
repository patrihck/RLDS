using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyMaintenanceProcessor
{
	public interface IUpdateCurrencyMaintenanceProcessor
	{
		Currency UpdateCurrency(long currencyId, object currencyFragment);
	}
}
