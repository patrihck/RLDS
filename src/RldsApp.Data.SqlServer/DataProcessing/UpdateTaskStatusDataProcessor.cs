using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class UpdateTaskStatusDataProcessor : IUpdateTaskStatusDataProcessor
	{
		private readonly ISession _session;

		public UpdateTaskStatusDataProcessor(ISession session)
		{
			_session = session;
		}

		public void UpdateTaskStatus(Task taskToUpdate, string statusName)
		{
			var status = _session.QueryOver<TransactionStatus>().Where(x => x.Name == statusName).SingleOrDefault();
			taskToUpdate.Status = status;
			_session.SaveOrUpdate(taskToUpdate);
		}
	}
}
