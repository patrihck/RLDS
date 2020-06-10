using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class AcccountMap : VersionedClassMap<Account>
	{
		public AcccountMap()
		{
			Id(x => x.Id, "AccountId");
			Map(x => x.Name).Not.Nullable();
			References(x => x.User, "UserId");
			References(x => x.Currency, "CurrencyId");
			References(x => x.Group, "GroupId").Nullable();
			Map(x => x.StartAmount).Not.Nullable();
		}
	}
}
