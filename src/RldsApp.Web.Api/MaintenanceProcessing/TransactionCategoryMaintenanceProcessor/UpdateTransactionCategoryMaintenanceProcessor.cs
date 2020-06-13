using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionCategoryMaintenanceProcessor
{
	public class UpdateTransactionCategoryMaintenanceProcessor : IUpdateTransactionCategoryMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateTransactionCategoryDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

		public UpdateTransactionCategoryMaintenanceProcessor(IUpdateTransactionCategoryDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
		}

		public TransactionCategory UpdateTransactionCategory(long transactionCategoryId, object transactionCategoryFragment)
		{
			var transactionCategoryFragmentAsJObject = (JObject)transactionCategoryFragment;
			var transactionCategoryContainingUpdateData = transactionCategoryFragmentAsJObject.ToObject<TransactionCategory>();
			var updatedPropertyValueMap = GetPropertyValueMap(transactionCategoryFragmentAsJObject, transactionCategoryContainingUpdateData);
			var updatedTransactionCategoryEntity = _dataProcessor.UpdateTransactionCategory(transactionCategoryId, updatedPropertyValueMap);
			var transactionCategory = _autoMapper.Map<TransactionCategory>(updatedTransactionCategoryEntity);

			return transactionCategory;
		}

		public virtual PropertyValueMapType GetPropertyValueMap(JObject transactionCategoryFragment, TransactionCategory transactionCategoryContainingUpdateData)
		{
			var namesOfModifiedProperties = _updateablePropertyDetector.GetNamesOfPropertiesToUpdate<TransactionCategory>(transactionCategoryFragment).ToList();
			var propertyInfos = typeof(TransactionCategory).GetProperties();
			var updatedPropertyValueMap = new PropertyValueMapType();

			foreach (var propertyName in namesOfModifiedProperties)
			{
				var propertyValue = propertyInfos.Single(x => x.Name == propertyName)
					.GetValue(transactionCategoryContainingUpdateData);

				updatedPropertyValueMap.Add(propertyName, propertyValue);
			}

			return updatedPropertyValueMap;
		}
	}
}
