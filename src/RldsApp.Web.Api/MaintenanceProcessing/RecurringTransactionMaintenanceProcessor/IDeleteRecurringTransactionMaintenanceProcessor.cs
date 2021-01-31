namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
	public interface IDeleteRecurringTransactionMaintenanceProcessor
	{
		bool DeleteTransaction(long recurringTransactionId);
	}
}
