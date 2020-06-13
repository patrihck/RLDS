using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface ITransactionCategoryByIdDataProcessor
	{
		TransactionCategory GetTransactionCategoryById(long transactionCategoryId);
	}
}
