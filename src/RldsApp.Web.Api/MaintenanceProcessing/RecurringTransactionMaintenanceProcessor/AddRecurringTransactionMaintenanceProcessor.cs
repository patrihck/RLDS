using AutoMapper;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
	public class AddRecurringTransactionMaintenanceProcessor : IAddRecurringTransactionMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddRecurringTransactionDataProcessor _dataProcessor;
		private readonly IRecurringTransactionLinkService _linkService;

		public AddRecurringTransactionMaintenanceProcessor(
			IAddRecurringTransactionDataProcessor dataProcessor,
			IMapper autoMapper,
			IRecurringTransactionLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
		}

		public RecurringTransaction AddRecurringTransaction(NewRecurringTransaction newRecurringTransaction)
		{
			var recurringTransactionEntity = _autoMapper.Map<Data.Entities.RecurringTransaction>(newRecurringTransaction);
			_dataProcessor.AddRecurringTransaction(recurringTransactionEntity);
			var transactionCategory = _autoMapper.Map<RecurringTransaction>(recurringTransactionEntity);
			_linkService.AddSelfLink(transactionCategory);

			return transactionCategory;
		}
	}
}
