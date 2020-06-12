using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using RldsApp.Web.Api.LinkServices;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyMaintenanceProcessor
{
	public class UpdateCurrencyMaintenanceProcessor : IUpdateCurrencyMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateCurrencyDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;
		private readonly ICurrencyLinkService _currencyLinkService;

		public UpdateCurrencyMaintenanceProcessor(IUpdateCurrencyDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector, ICurrencyLinkService currencyLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
			_currencyLinkService = currencyLinkService;
		}

		public Currency UpdateCurrency(long currencyId, object currencyFragment)
		{
			var currencyFragmentAsJObject = (JObject)currencyFragment;
			var currencyContainingUpdateData = currencyFragmentAsJObject.ToObject<Currency>();
			var updatedPropertyValueMap = GetPropertyValueMap(currencyFragmentAsJObject, currencyContainingUpdateData);
			var updatedCurrencyEntity = _dataProcessor.UpdateCurrency(currencyId, updatedPropertyValueMap);
			var currency = _autoMapper.Map<Currency>(updatedCurrencyEntity);
			_currencyLinkService.AddSelfLink(currency);

			return currency;
		}

		public virtual PropertyValueMapType GetPropertyValueMap(JObject currencyFragment, Currency currencyContainingUpdateData)
		{
			var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<Currency>(currencyFragment).ToList();
			var propertyInfos = typeof(Currency).GetProperties();
			var updatedPropertyValueMap = new PropertyValueMapType();

			foreach (var propertyName in namesOfModifiedProperties)
			{
				var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
					.GetValue(currencyContainingUpdateData);

				updatedPropertyValueMap.Add(propertyName, propertyValue);
			}

			return updatedPropertyValueMap;
		}
	}
}
