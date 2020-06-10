using FluentNHibernate.Mapping;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class TransactionStatusMap : ClassMap<TransactionStatus>
	{
		public TransactionStatusMap()
		{
			Id(x => x.Id, "TransactionStatusId").CustomType<TransactionStatusValue>();
			Map(x => x.Name).Not.Nullable();
			Map(x => x.Ordinal).Not.Nullable();
		}
	}
}
