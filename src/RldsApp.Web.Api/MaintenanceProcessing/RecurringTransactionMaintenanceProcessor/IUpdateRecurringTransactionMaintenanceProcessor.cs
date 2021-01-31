using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
	public interface IUpdateRecurringTransactionMaintenanceProcessor
	{
		RecurringTransaction UpdateRecurringTransaction(long recurringTransactionId, object recurringTransactionFragment);
	}
}
