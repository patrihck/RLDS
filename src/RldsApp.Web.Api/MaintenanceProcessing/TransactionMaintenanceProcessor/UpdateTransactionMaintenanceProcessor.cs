using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor
{
	public class UpdateTransactionMaintenanceProcessor : IUpdateTransactionMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateTransactionDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;
		private readonly ITransactionLinkService _linkService;

		public UpdateTransactionMaintenanceProcessor(
			IUpdateTransactionDataProcessor dataProcessor,
			IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector,
			ITransactionLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
			_linkService = linkService;
		}

		public Transaction UpdateTransaction(long transactionId, object fragment)
		{
			var fragmentAsJObject = (JObject)fragment;
			var model = fragmentAsJObject.ToObject<Transaction>();
			var entity = _autoMapper.Map<Data.Entities.Transaction>(model);
			var updatedPropertyValueMap = _updateablePropertyDetector.GetPropertyValueMap(fragmentAsJObject, model, entity);
			var updatedTransactionEntity = _dataProcessor.UpdateTransaction(transactionId, updatedPropertyValueMap);
			var transaction = _autoMapper.Map<Transaction>(updatedTransactionEntity);
			_linkService.AddSelfLink(transaction);
			_linkService.AddLinksToChildObjects(transaction);
			return transaction;
		}
	}
}
