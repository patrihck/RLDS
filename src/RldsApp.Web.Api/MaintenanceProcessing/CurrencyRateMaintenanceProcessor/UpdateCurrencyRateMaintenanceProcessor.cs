using System;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyRateMaintenanceProcessor
{
	public class UpdateCurrencyRateMaintenanceProcessor : IUpdateCurrencyRateMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateCurrencyRateDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;
		private readonly ICurrencyRateLinkService _currencyRateLinkService;

		public UpdateCurrencyRateMaintenanceProcessor(IMapper autoMapper, IUpdateCurrencyRateDataProcessor dataProcessor, IUpdateablePropertyDetector updateablePropertyDetector, ICurrencyRateLinkService currencyRateLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_updateablePropertyDetector = updateablePropertyDetector;
			_currencyRateLinkService = currencyRateLinkService;
		}

		public CurrencyRate UpdateCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date, object currencyRateFragment)
		{
			var currencyRateFragmentAsJObject = (JObject)currencyRateFragment;
			var currencyRateContainingUpdateData = currencyRateFragmentAsJObject.ToObject<CurrencyRate>();
			var updatedPropertyValueMap = GetPropertyValueMap(currencyRateFragmentAsJObject, currencyRateContainingUpdateData);
			var updatedCurrencyRateEntity = _dataProcessor.UpdateCurrencyRate(sourceCurrencyId, targetCurrencyId, date, updatedPropertyValueMap);
			var currencyRate = _autoMapper.Map<CurrencyRate>(updatedCurrencyRateEntity);
			_currencyRateLinkService.AddSelfLink(currencyRate);
			_currencyRateLinkService.AddLinksToChildObjects(currencyRate);

			return currencyRate;
		}

		public virtual PropertyValueMapType GetPropertyValueMap(JObject currencyRateFragmentAsJObject, CurrencyRate currencyRateContainingUpdateData)
		{
			var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<CurrencyRate>(currencyRateFragmentAsJObject).ToList();
			var propertyInfos = typeof(CurrencyRate).GetProperties();
			var updatedPropertyValueMap = new PropertyValueMapType();

			foreach (var propertyName in namesOfModifiedProperties)
			{
				var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
					.GetValue(currencyRateContainingUpdateData);

				updatedPropertyValueMap.Add(propertyName, propertyValue);
			}

			return updatedPropertyValueMap;
		}
	}
}
