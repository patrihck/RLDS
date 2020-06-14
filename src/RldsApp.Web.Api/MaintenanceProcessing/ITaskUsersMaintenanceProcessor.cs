using System.Collections.Generic;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface ITaskUsersMaintenanceProcessor
	{
		Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds);

		Task DeleteTaskUsers(long taskId);

		Task AddTaskUser(long taskId, long userId);

		Task DeleteTaskUser(long taskId, long userId);
	}
}
