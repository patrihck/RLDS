using System.Collections.Generic;
using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class TaskUsersMaintenanceProcessor : ITaskUsersMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateTaskDataProcessor _queryProcessor;

		public TaskUsersMaintenanceProcessor(IUpdateTaskDataProcessor queryProcessor, IMapper autoMapper)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
		}

		public Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds)
		{
			var taskEntity = _queryProcessor.ReplaceTaskUsers(taskId, userIds);
			return CreateTaskResponse(taskEntity);
		}

		public Task DeleteTaskUsers(long taskId)
		{
			var taskEntity = _queryProcessor.DeleteTaskUsers(taskId);
			return CreateTaskResponse(taskEntity);
		}

		public Task AddTaskUser(long taskId, long userId)
		{
			var taskEntity = _queryProcessor.AddTaskUser(taskId, userId);
			return CreateTaskResponse(taskEntity);
		}

		public Task DeleteTaskUser(long taskId, long userId)
		{
			var taskEntity = _queryProcessor.DeleteTaskUser(taskId, userId);
			return CreateTaskResponse(taskEntity);
		}

		public virtual Task CreateTaskResponse(Data.Entities.Task taskEntity)
		{
			var task = _autoMapper.Map<Task>(taskEntity);
			return task;
		}
	}
}
