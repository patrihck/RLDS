using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using Newtonsoft.Json.Linq;
using System.Linq;
using RldsApp.Data.DataProcessing.group;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class UpdateGroupMaintenanceProcessor : IUpdateGroupMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateGroupDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

		public UpdateGroupMaintenanceProcessor(IUpdateGroupDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
		}

		public Group UpdateGroup(long groupId, object groupFragment)
		{
			var groupFragmentAsJObject = (JObject)groupFragment;
			var groupContainingUpdateData = groupFragmentAsJObject.ToObject<Group>();
			var updatedPropertyValueMap = GetPropertyValueMap(groupFragmentAsJObject, groupContainingUpdateData);
			var updatedGroupEntity = _dataProcessor.GetUpdatedGroup(groupId, updatedPropertyValueMap);
			var group = _autoMapper.Map<Group>(updatedGroupEntity);

			return group;
		}

		public virtual PropertyValueMapType GetPropertyValueMap(JObject groupFragment, Group groupContainingUpdateData)
		{
			var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<Group>(groupFragment).ToList();
			var propertyInfos = typeof(Group).GetProperties();
			var updatedPropertyValueMap = new PropertyValueMapType();

			foreach (var propertyName in namesOfModifiedProperties)
			{
				var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
					.GetValue(groupContainingUpdateData);

				updatedPropertyValueMap.Add(propertyName, propertyValue);
			}

			return updatedPropertyValueMap;
		}
	}
}
