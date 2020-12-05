using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionRuleDataProcessor
{
	public interface IAllTransactionRulesDataProcessor
	{
		QueryResult<TransactionRule> GetTransactionRules(PagedDataRequest requestInfo);
	}
}
