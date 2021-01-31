using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class RecurringTransactionDayRuleMap : VersionedClassMap<RecurringTransactionDayRule>
	{
		public RecurringTransactionDayRuleMap()
		{
			Id(x => x.Id, "RecurringTransactionDayRuleId");
			Map(x => x.IsActive).Not.Nullable();
			Map(x => x.StartDate).Nullable();
			Map(x => x.EndDate).Nullable();

			References(x => x.RecurringTransaction, "RecurringTransactionId");
		}
	}
}
