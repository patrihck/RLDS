using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor
{
	public interface IUpdateTransactionMaintenanceProcessor
	{
		Transaction UpdateTransaction(long transactionId, object transactionFragment);
	}
}
