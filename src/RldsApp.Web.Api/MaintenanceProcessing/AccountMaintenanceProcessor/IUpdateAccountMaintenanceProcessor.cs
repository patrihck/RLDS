using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.AccountMaintenanceProcessor
{
	public interface IUpdateAccountMaintenanceProcessor
	{
		Account UpdateAccount(long accountId, object accountFragment);
	}
}
