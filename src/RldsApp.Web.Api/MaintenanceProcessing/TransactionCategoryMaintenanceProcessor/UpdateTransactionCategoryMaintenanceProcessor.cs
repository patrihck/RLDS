using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionCategoryMaintenanceProcessor
{
	public class UpdateTransactionCategoryMaintenanceProcessor : IUpdateTransactionCategoryMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateTransactionCategoryDataProcessor _dataProcessor;
		private readonly ITransactionCategoryLinkService _linkService;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

		public UpdateTransactionCategoryMaintenanceProcessor(IUpdateTransactionCategoryDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector, ITransactionCategoryLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
			_linkService = linkService;
		}

		public TransactionCategory UpdateTransactionCategory(long transactionCategoryId, object transactionCategoryFragment)
		{
			var fragmentAsJObject = (JObject)transactionCategoryFragment;
			var model = fragmentAsJObject.ToObject<TransactionCategory>();
			var entity = _autoMapper.Map<Data.Entities.TransactionCategory>(model);
			var updatedPropertyValueMap = _updateablePropertyDetector.GetPropertyValueMap(fragmentAsJObject, model, entity);
			var updatedTransactionCategoryEntity = _dataProcessor.UpdateTransactionCategory(transactionCategoryId, updatedPropertyValueMap);
			var transactionCategory = _autoMapper.Map<TransactionCategory>(updatedTransactionCategoryEntity);
			_linkService.AddSelfLink(transactionCategory);
			_linkService.AddLinksToChildObjects(transactionCategory);

			return transactionCategory;
		}
	}
}
