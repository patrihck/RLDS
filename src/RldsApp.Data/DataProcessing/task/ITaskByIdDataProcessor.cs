using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.task
{
    public interface ITaskByIdDataProcessor
    {
        Task GetTaskById(long taskId);
    }
}
