using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionTypeDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionTypeInquiryProcessor
{
	public class TransactionTypeByNameInquiryProcessor : ITransactionTypeByNameInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly ITransactionTypeByNameDataProcessor _dataProcessor;

		public TransactionTypeByNameInquiryProcessor(IMapper autoMapper, ITransactionTypeByNameDataProcessor dataProcessor)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
		}

		public TransactionType GetTransactionTypeByName(string transactionName)
		{
			var transactionTypeEntity = _dataProcessor.GetTransactionTypeByName(transactionName);

			if (transactionTypeEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.TransactionTypeNotFound);
			}

			var transactionType = GetMappedTransactionType(transactionTypeEntity);
			return transactionType;
		}

		public virtual TransactionType GetMappedTransactionType(Data.Entities.TransactionType transactionTypeEntity)
		{
			var transactionType = _autoMapper.Map<TransactionType>(transactionTypeEntity);
			return transactionType;
		}
	}
}
