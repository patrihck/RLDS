using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyMaintenanceProcessor
{
	public interface IAddCurrencyMaintenanceProcessor
	{
		Currency AddCurrency(NewCurrency newCurrency);
	}
}
