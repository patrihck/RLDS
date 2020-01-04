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

			References(x => x.CategoryId, "CategoryId");
			References(x => x.SourceAccountId, "SourceAccountId");
			References(x => x.TargetAccountId, "TargetAccountId");
			References(x => x.TransactionId, "TransactionId");
			References(x => x.TransactionStateId, "TransactionStateId");
			References(x => x.UserId, "UserId");
		}
	}
}
