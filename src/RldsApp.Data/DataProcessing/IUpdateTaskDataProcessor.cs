using RldsApp.Data.Entities;
using System.Collections.Generic;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing
{
    public interface IUpdateTaskDataProcessor
    {
        Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds);
        Task DeleteTaskUsers(long taskId);
        Task AddTaskUser(long taskId, long userId);
        Task DeleteTaskUser(long taskId, long userId);
        Task GetUpdatedTask(long taskId, PropertyValueMapType updatedPropertyValueMap);
    }
}
