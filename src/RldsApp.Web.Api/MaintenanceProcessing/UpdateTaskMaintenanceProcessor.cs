﻿using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using Newtonsoft.Json.Linq;
using System.Linq;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
    public class UpdateTaskMaintenanceProcessor : IUpdateTaskMaintenanceProcessor
    {
        private readonly IMapper _autoMapper;
        private readonly IUpdateTaskDataProcessor _queryProcessor;
        private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

        public UpdateTaskMaintenanceProcessor(IUpdateTaskDataProcessor queryProcessor, IMapper autoMapper, 
            IUpdateablePropertyDetector updateablePropertyDetector)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
            _updateablePropertyDetector = updateablePropertyDetector;
        }

        public Task UpdateTask(long taskId, object taskFragment)
        {
            var taskFragmentAsJObject = (JObject)taskFragment;
            var taskContainingUpdateData = taskFragmentAsJObject.ToObject<Task>();
            var updatedPropertyValueMap = GetPropertyValueMap(taskFragmentAsJObject, taskContainingUpdateData);
            var updatedTaskEntity = _queryProcessor.GetUpdatedTask(taskId, updatedPropertyValueMap);
            var task = _autoMapper.Map<Task>(updatedTaskEntity);

            return task;
        }

        public virtual PropertyValueMapType GetPropertyValueMap(JObject taskFragment, Task taskContainingUpdateData)
        {
            var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<Task>(taskFragment).ToList();
            var propertyInfos = typeof(Task).GetProperties();
            var updatedPropertyValueMap = new PropertyValueMapType();

            foreach (var propertyName in namesOfModifiedProperties)
            {
                var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
                    .GetValue(taskContainingUpdateData);

                updatedPropertyValueMap.Add(propertyName, propertyValue);
            }

            return updatedPropertyValueMap;
        }
    }
}