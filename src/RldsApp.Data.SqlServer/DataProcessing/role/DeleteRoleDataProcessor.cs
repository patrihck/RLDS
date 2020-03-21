using NHibernate;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.role
{
	public class DeleteGroupDataProcessor : IDeleteRoleDataProcessor
	{
		private readonly ISession _session;

		public DeleteGroupDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteRole(long roleId)
		{
			var result = false;
			var group = _session.Get<Role>(roleId);

			if (group != null)
			{
				_session.Delete(group);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
