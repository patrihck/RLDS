using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IAllTransactionCategoriesDataProcessor
	{
		QueryResult<TransactionCategory> GetTransactionCategories(PagedDataRequest requestInfo);
	}
}
