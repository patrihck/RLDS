using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class TaskByIdInquiryProcessor : ITaskByIdInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly ITaskByIdDataProcessor _queryProcessor;

		public TaskByIdInquiryProcessor(ITaskByIdDataProcessor queryProcessor, IMapper autoMapper)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
		}

		public Task GetTaskById(long taskId)
		{
			var taskEntity = _queryProcessor.GetTaskById(taskId);

			if (taskEntity == null)
			{
				throw new RootObjectNotFoundException("Task not found");
			}

			var task = _autoMapper.Map<Task>(taskEntity);
			return task;
		}
	}
}
