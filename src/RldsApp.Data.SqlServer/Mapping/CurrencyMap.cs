using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
    public class CurrencyMap : VersionedClassMap<Currency>
    {
        public CurrencyMap()
        {
            Id(x => x.CurrencyId);

            Map(x => x.CurrencyName).Not.Nullable();

            Map(x => x.CurrencySymbol).Not.Nullable();
        }
    }
}
