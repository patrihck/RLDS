using System.Linq;
using NHibernate;
using NHibernate.Util;
using RldsApp.Common;
using RldsApp.Common.Security;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class AddTaskDataProcessor : IAddTaskDataProcessor
	{
		private readonly IDateTime _dateTime;
		private readonly ISession _session;
		private readonly IUserSession _userSession;

		public AddTaskDataProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
		{
			_session = session;
			_userSession = userSession;
			_dateTime = dateTime;
		}

		public void AddTask(Task task)
		{
			task.CreatedDate = _dateTime.UtcNow;
			task.Status = _session.QueryOver<TransactionStatus>().Where(x => x.Name == "Not Started").SingleOrDefault();
			task.CreatedBy = _session.QueryOver<User>().Where(x => x.Login == _userSession.Login).SingleOrDefault();

			if (task.Assignees != null && task.Assignees.Any())
			{
				for (var i = 0; i < task.Assignees.Count; ++i)
				{
					var user = task.Assignees[i];
					var persistedUser = _session.Get<User>(user.Id);

					task.Assignees[i] = persistedUser ?? throw new ChildObjectNotFoundException("User not found");
				}
			}

			_session.SaveOrUpdate(task);
			_session.Flush();
		}
	}
}
