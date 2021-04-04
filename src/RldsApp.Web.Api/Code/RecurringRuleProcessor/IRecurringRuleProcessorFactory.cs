using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
    public interface IRecurringRuleProcessorFactory
	{
		bool CanHandle(RecurringRule rule);

		IRecurringRuleProcessor CreateProcessor(RecurringRule rule);
	}
}
