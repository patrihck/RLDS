using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.role
{
	public class AddRoleDataProcessor : IAddRoleDataProcessor
	{
		private readonly ISession _session;

		public AddRoleDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddRole(Role role)
		{
			_session.SaveOrUpdate(role);
		}
	}
}
