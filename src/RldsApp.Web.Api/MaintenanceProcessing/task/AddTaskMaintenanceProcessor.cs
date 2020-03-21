using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.task;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class AddTaskMaintenanceProcessor : IAddTaskMaintenanceProcessor
    {
        private readonly IMapper _autoMapper;
        private readonly IAddTaskDataProcessor _queryProcessor;
        private readonly ITaskLinkService _taskLinkService;

        public AddTaskMaintenanceProcessor(IAddTaskDataProcessor queryProcessor, IMapper autoMapper, ITaskLinkService taskLinkService)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
            _taskLinkService = taskLinkService;
        }

        public Task AddTask(NewTask newTask)
        {
            var taskEntity = _autoMapper.Map<Data.Entities.Task>(newTask);
            _queryProcessor.AddTask(taskEntity);
            var task = _autoMapper.Map<Task>(taskEntity);

            _taskLinkService.AddSelfLink(task);

            //task.AddLink(new Link
            //{
            //    Method = HttpMethod.Get.Method,
            //    Href = "http://localhost:49999/api/v1/tasks/" + task.TaskId,
            //    Rel = Constants.CommonLinkRelValues.Self
            //});

            return task;
        }
    }
}