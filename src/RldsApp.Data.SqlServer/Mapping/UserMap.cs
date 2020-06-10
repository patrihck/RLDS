using FluentNHibernate.Mapping;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class UserMap : VersionedClassMap<User>
	{
		public UserMap()
		{
			Id(x => x.Id, "UserId");
			Map(x => x.Login).Not.Nullable();
			Map(x => x.Password).Not.Nullable();
			Map(x => x.Firstname).Nullable();
			Map(x => x.Lastname).Nullable();
			Map(x => x.Email).Not.Nullable();

			HasManyToMany(x => x.Roles)
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Table("UserRole")
				.ParentKeyColumn("UserId")
				.ChildKeyColumn("RoleId");
		}
	}
}
