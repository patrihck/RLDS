using NHibernate;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.role
{
	public class RoleByIdDataProcessor : IRoleByIdDataProcessor
	{
		private readonly ISession _session;

		public RoleByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public Role GetRoleById(long roleId)
		{
			var role = _session.Get<Role>(roleId);
			return role;
		}

	}
}
