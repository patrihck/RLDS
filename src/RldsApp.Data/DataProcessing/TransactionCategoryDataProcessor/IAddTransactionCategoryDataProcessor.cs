using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IAddTransactionCategoryDataProcessor
	{
		void AddTransactionCategory(TransactionCategory transactionCategory);
	}
}
