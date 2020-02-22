using FluentNHibernate.Mapping;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class GroupMap : VersionedClassMap<Group>
	{
		public GroupMap()
		{
			Id(x => x.GroupId, "GroupId");
			Map(x => x.Name).Not.Nullable();
			Map(x => x.Info).Not.Nullable();
			Map(x => x.Ordinal).Not.Nullable();
		}
	}
}
