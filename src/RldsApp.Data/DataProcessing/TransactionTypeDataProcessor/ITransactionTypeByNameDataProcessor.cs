using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionTypeDataProcessor
{
	public interface ITransactionTypeByNameDataProcessor
	{
		TransactionType GetTransactionTypeByName(string name);
	}
}
