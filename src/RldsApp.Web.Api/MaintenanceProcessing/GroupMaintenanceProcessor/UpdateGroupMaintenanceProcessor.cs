using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing.GroupDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing.GroupMaintenanceProcessor
{
	public class UpdateGroupMaintenanceProcessor : IUpdateGroupMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateGroupDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;
		private readonly IGroupLinkService _groupLinkService;

		public UpdateGroupMaintenanceProcessor(IMapper autoMapper, IUpdateGroupDataProcessor dataProcessor,
			IUpdateablePropertyDetector updateablePropertyDetector, IGroupLinkService groupLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_updateablePropertyDetector = updateablePropertyDetector;
			_groupLinkService = groupLinkService;
		}

		public Group UpdateGroup(long groupId, object groupFragment)
		{
			var groupFragmentAsJObject = (JObject)groupFragment;
			var groupContainingUpdateData = groupFragmentAsJObject.ToObject<Group>();
			var updatedPropertyValueMap = GetPropertyValueMap(groupFragmentAsJObject, groupContainingUpdateData);
			var updatedGroupEntity = _dataProcessor.UpdateGroup(groupId, updatedPropertyValueMap);
			var group = _autoMapper.Map<Group>(updatedGroupEntity);
			_groupLinkService.AddSelfLink(group);

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
