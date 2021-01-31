using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
	public interface IAddRecurringTransactionMaintenanceProcessor
	{
		RecurringTransaction AddRecurringTransaction(NewRecurringTransaction newRecurringTransaction);
	}
}
