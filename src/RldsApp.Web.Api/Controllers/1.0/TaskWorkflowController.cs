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
	public class TaskWorkflowController : ControllerBase
	{
		private readonly IStartTaskWorkflowProcessor _startTaskWorkflowProcessor;
		private readonly ICompleteTaskWorkflowProcessor _completeTaskWorkflowProcessor;
		private readonly IReactivateTaskWorkflowProcessor _reactivateTaskWorkflowProcessor;

		public TaskWorkflowController(IStartTaskWorkflowProcessor startTaskWorkflowProcessor,
			ICompleteTaskWorkflowProcessor completeTaskWorkflowProcessor,
			IReactivateTaskWorkflowProcessor reactivateTaskWorkflowProcessor)
		{
			_startTaskWorkflowProcessor = startTaskWorkflowProcessor;
			_completeTaskWorkflowProcessor = completeTaskWorkflowProcessor;
			_reactivateTaskWorkflowProcessor = reactivateTaskWorkflowProcessor;
		}

		[HttpPost]
		[Route("tasks/{taskId:long}/activations", Name = "StartTaskRoute")]
		public Task StartTask(long taskId)
		{
			return _startTaskWorkflowProcessor.StartTask(taskId);
		}

		[HttpPost]
		[Route("tasks/{taskId:long}/completions", Name = "CompleteTaskRoute")]
		public Task CompleteTask(long taskId)
		{
			return _completeTaskWorkflowProcessor.CompleteTask(taskId);
		}

		[HttpPost]
		[Route("tasks/{taskId:long}/reactivations", Name = "ReactivateTaskRoute")]
		public Task ReactivateTask(long taskId)
		{
			return _reactivateTaskWorkflowProcessor.ReactivateTask(taskId);
		}
	}
}
