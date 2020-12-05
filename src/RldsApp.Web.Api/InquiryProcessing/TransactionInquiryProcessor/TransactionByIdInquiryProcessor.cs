using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.DataProcessing.TransactionRuleDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
	public class TransactionByIdInquiryProcessor : ITransactionByIdInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly ITransactionLinkService _linkService;
		private readonly ITransactionByIdDataProcessor _queryProcessor;

		public TransactionByIdInquiryProcessor(
			ITransactionByIdDataProcessor queryProcessor,
			IMapper autoMapper,
			ITransactionLinkService linkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
		}

		public Transaction GetTransactionById(long transactionId)
		{
			var transactionEntity = _queryProcessor.GetTransactionById(transactionId);

			if (transactionEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.TransactionNotFound);
			}

			var transaction = _autoMapper.Map<Transaction>(transactionEntity);
			_linkService.AddSelfLink(transaction);
			_linkService.AddLinksToChildObjects(transaction);
			return transaction;
		}
	}
}
