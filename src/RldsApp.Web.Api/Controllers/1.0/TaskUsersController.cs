using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.MaintenanceProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class TaskUsersController : ControllerBase
	{
		private readonly ITaskUsersMaintenanceProcessor _taskUsersMaintenanceProcessor;

		public TaskUsersController(ITaskUsersMaintenanceProcessor taskUsersMaintenanceProcessor)
		{
			_taskUsersMaintenanceProcessor = taskUsersMaintenanceProcessor;
		}

		[Route("{taskId:long}/users", Name = "ReplaceTaskUsersRoute")]
		[HttpPut]
		public Task ReplaceTaskUsers(long taskId, [FromBody] IEnumerable<long> userIds)
		{
			return _taskUsersMaintenanceProcessor.ReplaceTaskUsers(taskId, userIds);
		}

		[Route("{taskId:long}/users", Name = "DeleteTaskUsersRoute")]
		[HttpDelete]
		public Task DeleteTaskUsers(long taskId)
		{
			return _taskUsersMaintenanceProcessor.DeleteTaskUsers(taskId);
		}

		[Route("{taskId:long}/users/{userId:long}", Name = "AddTaskUserRoute")]
		[HttpPut]
		public Task AddTaskUser(long taskId, long userId)
		{
			return _taskUsersMaintenanceProcessor.AddTaskUser(taskId, userId);
		}

		[Route("{taskId:long}/users/{userId:long}", Name = "DeleteTaskUserRoute")]
		[HttpDelete]
		public Task DeleteTaskUser(long taskId, long userId)
		{
			return _taskUsersMaintenanceProcessor.DeleteTaskUser(taskId, userId);
		}
	}
}
