using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionTypeDataProcessor
{
	public interface IAllTransactionTypesDataProcessor
	{
		QueryResult<TransactionType> GetTransactionTypes(PagedDataRequest requestInfo);
	}
}
