using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class TaskByIdDataProcessor : ITaskByIdDataProcessor
	{
		private readonly ISession _session;

		public TaskByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public Task GetTaskById(long taskId)
		{
			var task = _session.Get<Task>(taskId);
			return task;
		}
	}
}
