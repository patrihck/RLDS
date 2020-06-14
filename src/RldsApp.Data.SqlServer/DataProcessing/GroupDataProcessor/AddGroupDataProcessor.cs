using NHibernate;
using RldsApp.Data.DataProcessing.GroupDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.GroupDataProcessor
{
	public class AddGroupDataProcessor : IAddGroupDataProcessor
	{
		private readonly ISession _session;

		public AddGroupDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddGroup(Group group)
		{
			_session.SaveOrUpdate(group);
		}
	}
}
