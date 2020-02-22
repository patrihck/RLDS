using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class TransactionMap : VersionedClassMap<Transaction>
	{
		public TransactionMap()
		{
			Id(x => x.TransactionId);
			Map(x => x.Date).Not.Nullable();
			Map(x => x.Description).Not.Nullable();
			Map(x => x.Amount).Not.Nullable();

			References(x => x.Category, "CategoryId");
			References(x => x.SourceAccount, "SourceAccountId");
			References(x => x.TargetAccount, "TargetAccountId");
			References(x => x.TransactionStatus, "TransactionStateId");
			References(x => x.User, "UserId");
		}
	}
}
