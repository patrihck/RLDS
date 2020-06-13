using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public class TransactionStatusByNameInquiryProcessor : ITransactionStatusByNameInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly ITransactionStatusByNameDataProcessor _queryProcessor;

		public TransactionStatusByNameInquiryProcessor(ITransactionStatusByNameDataProcessor queryProcessor, IMapper autoMapper)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
		}

		public TransactionStatus GetTransactionStatusByName(string statusName)
		{
			var transactionStatusEntity = _queryProcessor.GetTransactionStatusByName(statusName);

			if (transactionStatusEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.TransactionStatusNotFound);
			}

			var task = _autoMapper.Map<TransactionStatus>(transactionStatusEntity);
			return task;
		}
	}
}
