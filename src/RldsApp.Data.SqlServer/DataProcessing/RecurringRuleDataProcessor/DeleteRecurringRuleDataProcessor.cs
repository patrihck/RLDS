using NHibernate;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringRuleDataProcessor
{
	public class DeleteRecurringRuleDataProcessor : IDeleteRecurringRuleDataProcessor
	{
		private readonly ISession _session;

		public DeleteRecurringRuleDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteRecurringRule(long recurringRuleId)
		{
			var result = false;
			var recurringRule = _session.Get<RecurringRule>(recurringRuleId);

			if (recurringRule != null)
			{
				_session.Delete(recurringRule);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
