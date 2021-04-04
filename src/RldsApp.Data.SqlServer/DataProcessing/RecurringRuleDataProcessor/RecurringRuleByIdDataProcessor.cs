using NHibernate;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringRuleDataProcessor
{
	public class RecurringRuleByIdDataProcessor : IRecurringRuleByIdDataProcessor
	{
		private readonly ISession _session;

		public RecurringRuleByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public RecurringRule GetRecurringRuleById(long recurringRuleId)
		{
			var recurringRule = _session.Get<RecurringRule>(recurringRuleId);
			return recurringRule;
		}
	}
}
