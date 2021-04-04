using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class TransactionMap : VersionedClassMap<Transaction>
	{
		public TransactionMap()
		{
			Id(x => x.Id, "TransactionId");
			Map(x => x.Date).Not.Nullable();
			Map(x => x.Description).Nullable();
			Map(x => x.Amount).Not.Nullable();

			References(x => x.User, "UserId");
			References(x => x.Sender, "SenderId");
			References(x => x.Receiver, "ReceiverId");
			References(x => x.Type, "TypeId");
			References(x => x.Category, "CategoryId");
			References(x => x.Status, "StatusId");
			References(x => x.Currency, "CurrencyId");
			References(x => x.RecurringRule, "RecurringTransactionId").Nullable();
		}
	}
}
