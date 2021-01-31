using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
	public class UpdateRecurringTransactionMaintenanceProcessor : IUpdateRecurringTransactionMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateRecurringTransactionDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;
		private readonly IRecurringTransactionLinkService _linkService;

		public UpdateRecurringTransactionMaintenanceProcessor(
			IUpdateRecurringTransactionDataProcessor dataProcessor,
			IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector,
			IRecurringTransactionLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
			_linkService = linkService;
		}

		public RecurringTransaction UpdateRecurringTransaction(long recurringTransationId, object fragment)
		{
			var fragmentAsJObject = (JObject)fragment;
			var model = fragmentAsJObject.ToObject<RecurringTransaction>();
			var entity = _autoMapper.Map<Data.Entities.RecurringTransaction>(model);
			var updatedPropertyValueMap = _updateablePropertyDetector.GetPropertyValueMap(fragmentAsJObject, model, entity);
			var updatedRecurringTransactionEntity = _dataProcessor.UpdateRecurringTransaction(recurringTransationId, updatedPropertyValueMap);
			var recurringTransaction = _autoMapper.Map<RecurringTransaction>(updatedRecurringTransactionEntity);
			_linkService.AddSelfLink(recurringTransaction);
			return recurringTransaction;
		}
	}
}
