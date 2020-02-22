using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
    public class TransactionStatusMap : VersionedClassMap<TransactionStatus>
    {
        public TransactionStatusMap()
        {
            Id(x => x.TransactionStatusId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Ordinal).Not.Nullable();
        }
    }
}
