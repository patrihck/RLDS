using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class TransactionCategoryMap : VersionedClassMap<TransactionCategory>
	{
		public TransactionCategoryMap()
		{
			Id(x => x.Id, "TransactionCategoryId");
			Map(x => x.Name).Not.Nullable();
			References(x => x.Root, "RootId").Nullable();
		}
	}
}
