using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.group
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
