using NHibernate;
using RldsApp.Data.DataProcessing.task;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.task
{
    public class UpdateTaskStatusDataProcessor : IUpdateTaskStatusDataProcessor
    {
        private readonly ISession _session;

        public UpdateTaskStatusDataProcessor(ISession session)
        {
            _session = session;
        }

        public void UpdateTaskStatus(Task taskToUpdate, long taskStatusId)
        {
            var taskStatus = _session.QueryOver<TaskStatus>().Where(x => x.TaskStatusId == taskStatusId).SingleOrDefault();
            taskToUpdate.Status = taskStatus;
            _session.SaveOrUpdate(taskToUpdate);
        }

        public void UpdateTaskStatus(Task taskToUpdate, string taskStatusName)
        {
            var taskStatus = _session.QueryOver<TaskStatus>().Where(x => x.Name == taskStatusName).SingleOrDefault();
            taskToUpdate.Status = taskStatus;
            _session.SaveOrUpdate(taskToUpdate);
        }
    }
}
