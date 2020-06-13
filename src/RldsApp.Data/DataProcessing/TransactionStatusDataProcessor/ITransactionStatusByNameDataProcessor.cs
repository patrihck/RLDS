using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionStatusDataProcessor
{
	public interface ITransactionStatusByNameDataProcessor
	{
		TransactionStatus GetTransactionStatusByName(string statusName);
	}
}
