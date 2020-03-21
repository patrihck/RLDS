using NHibernate;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.group
{
	public class UserByIdDataProcessor : IGroupByIdDataProcessor
	{
		private readonly ISession _session;

		public UserByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public Group GetGroupById(long groupId)
		{
			var group = _session.Get<Group>(groupId);
			return group;
		}

	}
}
