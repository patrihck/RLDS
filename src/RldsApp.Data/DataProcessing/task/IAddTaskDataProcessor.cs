using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.task
{
    public interface IAddTaskDataProcessor
    {
        void AddTask(Task task);
    }
}
