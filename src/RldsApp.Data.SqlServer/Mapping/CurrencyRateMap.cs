using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class CurrencyRateMap : VersionedClassMap<CurrencyRate>
	{
		public CurrencyRateMap()
		{
			CompositeId()
				.KeyReference(x => x.SourceCurrency, "SourceCurrencyId")
				.KeyReference(x => x.TargetCurrency, "TargetCurrencyId")
				.KeyProperty(x => x.Date, "Date");
			Map(x => x.Rate).Not.Nullable();
		}
	}
}
