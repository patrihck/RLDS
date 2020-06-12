using NHibernate;
using RldsApp.Data.DataProcessing.RoleDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RoleDataProcessor
{
	public class RoleByNameDataProcessor : IRoleByNameDataProcessor
	{
		private readonly ISession _session;

		public RoleByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public Role GetRoleByName(string roleName)
		{
			var role = _session.QueryOver<Role>().Where(x => x.RoleName == roleName).SingleOrDefault();

			return role;
		}
	}
}
