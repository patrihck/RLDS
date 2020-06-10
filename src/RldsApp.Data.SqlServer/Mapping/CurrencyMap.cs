using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class CurrencyMap : VersionedClassMap<Currency>
	{
		public CurrencyMap()
		{
			Id(x => x.Id, "CurrencyId");
			Map(x => x.Name).Not.Nullable();
			Map(x => x.Acronym).Nullable();
			Map(x => x.Symbol).Nullable();
			Map(x => x.IsPrefix).Nullable();
		}
	}
}
