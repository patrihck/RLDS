using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IUpdateTransactionCategoryMaintenanceProcessor
	{
		TransactionCategory UpdateTransactionCategory(long transactionCategoryId, object transactionCategoryFragment);
	}
}
