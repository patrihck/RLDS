using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.task
{
    public interface IAllTasksDataProcessor
    {
        QueryResult<Task> GetTasks(PagedDataRequest requestInfo);
    }
}
