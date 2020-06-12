using NHibernate;
using RldsApp.Data.DataProcessing.GroupDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.GroupDataProcessor
{
	public class GroupByIdDataProcessor : IGroupByIdDataProcessor
	{
		private readonly ISession _session;

		public GroupByIdDataProcessor(ISession session)
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
