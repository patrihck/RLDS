namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IDeleteTransactionCategoryMaintenanceProcessor
	{
		bool DeleteTransactionCategory(long transactionCategoryId);
	}
}
