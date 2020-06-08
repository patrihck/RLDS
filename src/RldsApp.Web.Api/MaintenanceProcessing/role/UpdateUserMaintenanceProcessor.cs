using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using Newtonsoft.Json.Linq;
using System.Linq;
using RldsApp.Data.DataProcessing.role;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class UpdateRoleMaintenanceProcessor : IUpdateRoleMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateRoleDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

		public UpdateRoleMaintenanceProcessor(IUpdateRoleDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
		}

		public Role UpdateRole(long roleId, object roleFragment)
		{
			var roleFragmentAsJObject = (JObject)roleFragment;
			var roleContainingUpdateData = roleFragmentAsJObject.ToObject<Role>();
			var updatedPropertyValueMap = GetPropertyValueMap(roleFragmentAsJObject, roleContainingUpdateData);
			var updatedRoleEntity = _dataProcessor.GetUpdatedRole(roleId, updatedPropertyValueMap);
			var role = _autoMapper.Map<Role>(updatedRoleEntity);

			return role;
		}

		public virtual PropertyValueMapType GetPropertyValueMap(JObject roleFragment, Role roleContainingUpdateData)
		{
			var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<Role>(roleFragment).ToList();
			var propertyInfos = typeof(Role).GetProperties();
			var updatedPropertyValueMap = new PropertyValueMapType();

			foreach (var propertyName in namesOfModifiedProperties)
			{
				var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
					.GetValue(roleContainingUpdateData);

				updatedPropertyValueMap.Add(propertyName, propertyValue);
			}

			return updatedPropertyValueMap;
		}
	}
}
