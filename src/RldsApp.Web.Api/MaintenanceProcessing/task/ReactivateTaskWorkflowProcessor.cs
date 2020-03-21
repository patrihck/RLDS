using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.Exceptions;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.task;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
    public class ReactivateTaskWorkflowProcessor : IReactivateTaskWorkflowProcessor
    {
        private readonly IMapper _autoMapper;
        private readonly ITaskByIdDataProcessor _taskByIdQueryProcessor;
        private readonly IUpdateTaskStatusDataProcessor _updateTaskStatusQueryProcessor;

        public ReactivateTaskWorkflowProcessor(ITaskByIdDataProcessor taskByIdQueryProcessor, 
            IUpdateTaskStatusDataProcessor updateTaskStatusQueryProcessor, IMapper autoMapper)
        {
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
            _autoMapper = autoMapper;
        }

        public Task ReactivateTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTaskById(taskId);
            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task not found");
            }

            // Simulate some workflow logic...
            if (taskEntity.Status.Name != "Completed")
            {
                throw new BusinessRuleViolationException(
                "Incorrect task status. Expected status of 'Completed'.");
            }

            taskEntity.CompletedDate = null;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "In Progress");

            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }
    }
}