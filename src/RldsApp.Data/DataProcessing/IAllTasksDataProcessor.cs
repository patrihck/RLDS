using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
    public interface IAllTasksDataProcessor
    {
        QueryResult<Task> GetTasks(PagedDataRequest requestInfo);
    }
}
