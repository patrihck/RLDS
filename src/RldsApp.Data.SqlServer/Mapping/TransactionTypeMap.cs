using FluentNHibernate.Mapping;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class TransactionTypeMap : ClassMap<TransactionType>
	{
		public TransactionTypeMap()
		{
			Id(x => x.Id, "TransactionTypeId").CustomType<TransactionTypeValue>();
			Map(x => x.Name).Not.Nullable();
		}
	}
}
