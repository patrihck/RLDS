using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.AccountMaintenanceProcessor
{
	public interface IAddAccountMaintenanceProcessor
	{
		Account AddAccount(NewAccount newAccount);
	}
}
