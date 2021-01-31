using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class RecurringTransactionMap : VersionedClassMap<RecurringTransaction>
	{
		public RecurringTransactionMap()
		{
			Id(x => x.Id, "RecurringTransactionId");
			Map(x => x.Description).Nullable();
			Map(x => x.Amount).Not.Nullable();

			References(x => x.User, "UserId");
			References(x => x.Sender, "SenderId");
			References(x => x.Receiver, "ReceiverId");
			References(x => x.Type, "TypeId");
			References(x => x.Category, "CategoryId");
			References(x => x.Currency, "CurrencyId");

			HasMany(x => x.RecurringTransactionDayRules).KeyColumn("RecurringTransactionId");
			HasMany(x => x.RecurringTransactionWeekRules).KeyColumn("RecurringTransactionId");
			HasMany(x => x.RecurringTransactionMonthRules).KeyColumn("RecurringTransactionId");
		}
	}
}
