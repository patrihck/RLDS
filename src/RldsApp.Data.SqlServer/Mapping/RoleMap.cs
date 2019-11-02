using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class RoleMap : VersionedClassMap<Role>
	{
		public RoleMap()
		{
			Id(x => x.RoleId);
			Map(x => x.RoleName).Not.Nullable();
		}
	}
}
