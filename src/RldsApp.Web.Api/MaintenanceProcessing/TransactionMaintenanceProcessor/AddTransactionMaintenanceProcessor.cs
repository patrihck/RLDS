using AutoMapper;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor
{
	public class AddTransactionMaintenanceProcessor : IAddTransactionMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddTransactionDataProcessor _dataProcessor;
		private readonly ITransactionLinkService _linkService;

		public AddTransactionMaintenanceProcessor(
			IAddTransactionDataProcessor dataProcessor,
			IMapper autoMapper,
			ITransactionLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
		}

		public Transaction AddTransaction(NewTransaction newTransaction)
		{
			var transactionEntity = _autoMapper.Map<Data.Entities.Transaction>(newTransaction);
			var addedTransactionEntity = _dataProcessor.AddTransaction(transactionEntity);
			var transaction = _autoMapper.Map<Transaction>(addedTransactionEntity);
			_linkService.AddSelfLink(transaction);
			_linkService.AddLinksToChildObjects(transaction);

			return transaction;
		}
	}
}
