using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public class RecurringTransactionByIdInquiryProcessor : IRecurringTransactionByIdInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IRecurringTransactionLinkService _linkService;
		private readonly IRecurringTransactionByIdDataProcessor _queryProcessor;

		public RecurringTransactionByIdInquiryProcessor(
			IRecurringTransactionByIdDataProcessor queryProcessor,
			IMapper autoMapper,
			IRecurringTransactionLinkService linkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
		}

		public RecurringTransaction GetRecurringTransactionById(long recurringTransactionId)
		{
			var recurringTransactionEntity = _queryProcessor.GetRecurringTransactionById(recurringTransactionId);

			if (recurringTransactionEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.RecurringTransactionNotFound);
			}

			var recurringTransaction = _autoMapper.Map<RecurringTransaction>(recurringTransactionEntity);
			_linkService.AddSelfLink(recurringTransaction);
			return recurringTransaction;
		}
	}
}
