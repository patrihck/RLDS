using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class TasksController : ControllerBase
	{
		private readonly ITaskByIdInquiryProcessor _taskByIdInquiryProcessor;
		private readonly IAllTasksInquiryProcessor _allTasksInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		//private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;
		//private readonly IUpdateTaskMaintenanceProcessor _updateTaskMaintenanceProcessor;

		public TasksController(ITaskByIdInquiryProcessor taskByIdInquiryProcessor, IAllTasksInquiryProcessor allTasksInquiryProcessor, IPagedDataRequestFactory pagedDataRequestFactory)
		//IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor,
		//IUpdateTaskMaintenanceProcessor updateTaskMaintenanceProcessor,
		{
			_taskByIdInquiryProcessor = taskByIdInquiryProcessor;
			_allTasksInquiryProcessor = allTasksInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			//_addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
			//_updateTaskMaintenanceProcessor = updateTaskMaintenanceProcessor;
		}

		[HttpGet("{id:long}")]
		public Task GetTaskById(long id)
		{
			return _taskByIdInquiryProcessor.GetTaskById(id);
		}

		[HttpGet]
		public PagedDataInquiryResponse<Task> GetTasks()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allTasksInquiryProcessor.GetTasks(request);
		}

		//[Route("", Name = "AddTaskRoute")]
		//[HttpPost]
		//[Authorize(Roles = Constants.RoleNames.Admin)]
		//public ActionResult AddTask(HttpRequestMessage requestMessage, NewTask newTask)
		//{
		//	var task = _addTaskMaintenanceProcessor.AddTask(newTask);
		//	return CreatedAtAction(nameof(GetTaskById), new { id = task.TaskId }, task);
		//}

		//[Route("{id:long}", Name = "UpdateTaskRoute")]
		//[HttpPut]
		//[Authorize(Roles = Constants.RoleNames.SuperUser)]
		//public Task UpdateTask(long id, [FromBody] object updatedTask)
		//{
		//	var task = _updateTaskMaintenanceProcessor.UpdateTask(id, updatedTask);
		//	return task;
		//}
	}
}
