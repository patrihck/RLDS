using FluentNHibernate.Mapping;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class RoleMap : VersionedClassMap<Role>
	{
		public RoleMap()
		{
			Id(x => x.Id, "RoleId");
			Map(x => x.RoleName).Not.Nullable();

			HasManyToMany(x => x.Users)
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Table("UserRole")
				.ParentKeyColumn("RoleId")
				.ChildKeyColumn("UserId");
		}
	}
}
