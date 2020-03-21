using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.task
{
    public interface IUpdateTaskStatusDataProcessor
    {
        void UpdateTaskStatus(Task taskToUpdate, string statusName);
    }
}
