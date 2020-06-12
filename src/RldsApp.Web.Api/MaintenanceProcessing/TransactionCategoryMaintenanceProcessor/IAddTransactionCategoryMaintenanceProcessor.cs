using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IAddTransactionCategoryMaintenanceProcessor
	{
		TransactionCategory AddTransactionCategory(NewTransactionCategory newTransactionCategory);
	}
}
