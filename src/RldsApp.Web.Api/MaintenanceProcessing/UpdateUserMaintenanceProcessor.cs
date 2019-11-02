using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using Newtonsoft.Json.Linq;
using System.Linq;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class UpdateUserMaintenanceProcessor : IUpdateUserMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateUserDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

		public UpdateUserMaintenanceProcessor(IUpdateUserDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
		}

		public User UpdateUser(long userId, object userFragment)
		{
			var userFragmentAsJObject = (JObject)userFragment;
			var userContainingUpdateData = userFragmentAsJObject.ToObject<User>();
			var updatedPropertyValueMap = GetPropertyValueMap(userFragmentAsJObject, userContainingUpdateData);
			var updatedUserEntity = _dataProcessor.GetUpdatedUser(userId, updatedPropertyValueMap);
			var user = _autoMapper.Map<User>(updatedUserEntity);

			return user;
		}

		public virtual PropertyValueMapType GetPropertyValueMap(JObject userFragment, User userContainingUpdateData)
		{
			var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<User>(userFragment).ToList();
			var propertyInfos = typeof(User).GetProperties();
			var updatedPropertyValueMap = new PropertyValueMapType();

			foreach (var propertyName in namesOfModifiedProperties)
			{
				var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
					.GetValue(userContainingUpdateData);

				updatedPropertyValueMap.Add(propertyName, propertyValue);
			}

			return updatedPropertyValueMap;
		}
	}
}
