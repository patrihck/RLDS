using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionRuleDataProcessor
{
	public interface ITransactionRuleByIdDataProcessor
	{
		TransactionRule GetTransactionRuleById(long transactionRuleId);
	}
}
