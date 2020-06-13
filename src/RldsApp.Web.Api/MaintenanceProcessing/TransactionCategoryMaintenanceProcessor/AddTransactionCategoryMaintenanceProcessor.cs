using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionCategoryMaintenanceProcessor
{
	public class AddTransactionCategoryMaintenanceProcessor : IAddTransactionCategoryMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddTransactionCategoryDataProcessor _dataProcessor;
		private readonly ITransactionCategoryLinkService _linkService;

		public AddTransactionCategoryMaintenanceProcessor(IAddTransactionCategoryDataProcessor dataProcessor, IMapper autoMapper, ITransactionCategoryLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
		}

		public TransactionCategory AddTransactionCategory(NewTransactionCategory newTransactionCategory)
		{
			var transactionCategoryEntity = _autoMapper.Map<Data.Entities.TransactionCategory>(newTransactionCategory);
			_dataProcessor.AddTransactionCategory(transactionCategoryEntity);
			var transactionCategory = _autoMapper.Map<TransactionCategory>(transactionCategoryEntity);
			_linkService.AddSelfLink(transactionCategory);

			return transactionCategory;
		}
	}
}
