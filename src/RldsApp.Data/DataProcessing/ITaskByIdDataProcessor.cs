using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
    public interface ITaskByIdDataProcessor
    {
        Task GetTaskById(long taskId);
    }
}
