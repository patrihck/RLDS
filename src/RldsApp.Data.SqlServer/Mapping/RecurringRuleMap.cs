using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class RecurringRuleMap : VersionedClassMap<RecurringRule>
	{
		public RecurringRuleMap()
		{
			Id(x => x.Id, "RecurringRuleId");
			Map(x => x.Description).Nullable();
			Map(x => x.Amount).Not.Nullable();

			References(x => x.User, "UserId");
			References(x => x.Sender, "SenderId");
			References(x => x.Receiver, "ReceiverId"); 
			References(x => x.Category, "CategoryId");
			References(x => x.Currency, "CurrencyId");

			HasMany(x => x.DailyPeriods).KeyColumn("RecurringRuleId");
			HasMany(x => x.WeeklyPeriods).KeyColumn("RecurringRuleId");
			HasMany(x => x.MonthlyPeriods).KeyColumn("RecurringRuleId");
		}
	}
}
