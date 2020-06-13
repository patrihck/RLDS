namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor
{
	public interface IDeleteTransactionMaintenanceProcessor
	{
		bool DeleteTransaction(long transactionId);
	}
}
