using NHibernate;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.group
{
	public class DeleteGroupDataProcessor : IDeleteGroupDataProcessor
	{
		private readonly ISession _session;

		public DeleteGroupDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteGroup(long groupId)
		{
			var result = false;
			var group = _session.Get<Group>(groupId);

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
