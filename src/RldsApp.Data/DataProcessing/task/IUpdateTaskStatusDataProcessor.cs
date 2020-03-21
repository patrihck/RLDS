using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.task
{
    public interface IUpdateTaskStatusDataProcessor
    {
        void UpdateTaskStatus(Task taskToUpdate, long taskStatusId);
        void UpdateTaskStatus(Task taskToUpdate, string taskStatusName);
    }
}
