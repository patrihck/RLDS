using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class RecurringTransactionMonthRuleMap : VersionedClassMap<RecurringTransactionMonthRule>
	{
		public RecurringTransactionMonthRuleMap()
		{
			Id(x => x.Id, "RecurringTransactionMonthRuleId");
			Map(x => x.IsActive).Not.Nullable();
			Map(x => x.StartDate).Nullable();
			Map(x => x.EndDate).Nullable();
			Map(x => x.SelectedDay).Not.Nullable();

			References(x => x.RecurringTransaction, "RecurringTransactionId");
		}
	}
}
