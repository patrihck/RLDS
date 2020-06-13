using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public class TransactionStatusByIdInquiryProcessor : ITransactionStatusByIdInquiryProcess
	{
		private readonly IMapper _autoMapper;
		private readonly ITransactionStatusByIdDataProcessor _queryProcessor;

		public TransactionStatusByIdInquiryProcessor(ITransactionStatusByIdDataProcessor queryProcessor, IMapper autoMapper)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
		}

		public TransactionStatus GetTransactionStatusById(long statusId)
		{
			var transactionStatusEntity = _queryProcessor.GetTransactionStatusById(statusId);

			if (transactionStatusEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.TransactionStatusNotFound);
			}

			var task = _autoMapper.Map<TransactionStatus>(transactionStatusEntity);
			return task;
		}
	}
}
