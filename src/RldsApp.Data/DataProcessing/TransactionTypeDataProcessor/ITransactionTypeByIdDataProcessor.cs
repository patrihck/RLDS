using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionTypeDataProcessor
{
	public interface ITransactionTypeByIdDataProcessor
	{
		TransactionType GetTransactionTypeById(TransactionTypeValue transactionTypeId);
	}
}
