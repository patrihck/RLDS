using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor
{
	public interface IAddTransactionMaintenanceProcessor
	{
		Transaction AddTransaction(NewTransaction newTransaction);
	}
}
