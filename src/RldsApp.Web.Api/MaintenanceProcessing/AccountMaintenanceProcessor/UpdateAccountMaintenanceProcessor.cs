using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing.AccountMaintenanceProcessor
{
	public class UpdateAccountMaintenanceProcessor : IUpdateAccountMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateAccountDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

		public UpdateAccountMaintenanceProcessor(IUpdateAccountDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
		}

		public Account UpdateAccount(long accountId, object accountFragment)
		{
			var accountFragmentAsJObject = (JObject)accountFragment;
			var accountContainingUpdateData = accountFragmentAsJObject.ToObject<Account>();
			var updatedPropertyValueMap = GetPropertyValueMap(accountFragmentAsJObject, accountContainingUpdateData);
			var updatedAccountEntity = _dataProcessor.UpdateAccount(accountId, updatedPropertyValueMap);
			var account = _autoMapper.Map<Account>(updatedAccountEntity);

			return account;
		}

		public virtual PropertyValueMapType GetPropertyValueMap(JObject accountFragment, Account accountContainingUpdateData)
		{
			var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<Account>(accountFragment).ToList();
			var propertyInfos = typeof(Account).GetProperties();
			var updatedPropertyValueMap = new PropertyValueMapType();

			foreach (var propertyName in namesOfModifiedProperties)
			{
				var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
					.GetValue(accountContainingUpdateData);

				updatedPropertyValueMap.Add(propertyName, propertyValue);
			}

			return updatedPropertyValueMap;
		}
	}
}
