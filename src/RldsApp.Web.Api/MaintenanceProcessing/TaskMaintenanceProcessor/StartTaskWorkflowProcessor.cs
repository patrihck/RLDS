using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class StartTaskWorkflowProcessor : IStartTaskWorkflowProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly ITaskByIdDataProcessor _taskByIdQueryProcessor;
		private readonly IDateTime _dateTime;
		private readonly IUpdateTaskStatusDataProcessor _updateTaskStatusQueryProcessor;

		public StartTaskWorkflowProcessor(ITaskByIdDataProcessor taskByIdQueryProcessor,
			IUpdateTaskStatusDataProcessor updateTaskStatusQueryProcessor, IMapper autoMapper,
			IDateTime dateTime)
		{
			_taskByIdQueryProcessor = taskByIdQueryProcessor;
			_updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
			_autoMapper = autoMapper;
			_dateTime = dateTime;
		}

		public Task StartTask(long taskId)
		{
			var taskEntity = _taskByIdQueryProcessor.GetTaskById(taskId);
			if (taskEntity == null)
			{
				throw new RootObjectNotFoundException("Task not found");
			}

			// Simulate some workflow logic...
			if (taskEntity.Status.Name != "Not Started")
			{
				throw new BusinessRuleViolationException("Incorrect task status. Expected status of 'Not Started'.");
			}

			taskEntity.StartDate = _dateTime.UtcNow;
			_updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "In Progress");

			var task = _autoMapper.Map<Task>(taskEntity);

			return task;
		}
	}
}
