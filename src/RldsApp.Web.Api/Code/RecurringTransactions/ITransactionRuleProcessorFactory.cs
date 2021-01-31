using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
    public interface ITransactionRuleProcessorFactory
	{
		bool CanHandle(RecurringTransactionRule rule);

		ITransactionRuleProcessor CreateProcessor(RecurringTransactionRule rule);
	}
}
