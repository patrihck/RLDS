using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringRuleDataProcessor
{
    public class UpdateRecurringRuleDataProcessor : IUpdateRecurringRuleDataProcessor
	{
		private readonly ISession _session;

		public UpdateRecurringRuleDataProcessor(ISession session)
		{
			_session = session;
		}

		public RecurringRule UpdateRecurringRule(long recurringRuleId, PropertyValueMapType updatedPropertyValueMap)
		{
			var recuringRule = _session.GetRootEntity<RecurringRule>(recurringRuleId, () => Messages.RecurringRuleNotFound);
			var propertyInfos = typeof(RecurringRule).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos
					.Single(x => x.Name == propertyValuePair.Key)
					.SetValue(recuringRule, propertyValuePair.Value);
			}

			AddRecurringRuleDataProcessor.GetChildEntities(_session, recuringRule);

			_session.SaveOrUpdate(recuringRule);
			_session.Flush();

			return recuringRule;
		}
	}
}
