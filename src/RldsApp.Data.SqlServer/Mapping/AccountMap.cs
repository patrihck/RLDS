using FluentNHibernate.Mapping;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class AcccountMap : VersionedClassMap<Account>
	{
		public AcccountMap()
		{
			Id(x => x.AccountId, "AccountId");
			Map(x => x.StartAmount, "StartAmount").Not.Nullable(); ;
			References(x => x.Currency, "CurrencyId");
			References(x => x.Group, "GroupId");
			References(x => x.AccountType, "AccountTypeId");

			HasManyToMany(x => x.Users)
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Table("UserAccount")
				.ParentKeyColumn("UserId")
				.ChildKeyColumn("AccountId");
		}
	}

}
