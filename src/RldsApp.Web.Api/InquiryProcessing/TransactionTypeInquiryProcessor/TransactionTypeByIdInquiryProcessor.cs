using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionTypeDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionTypeInquiryProcessor
{
	public class TransactionTypeByIdInquiryProcessor : ITransactionTypeByIdInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly ITransactionTypeByIdDataProcessor _dataProcessor;

		public TransactionTypeByIdInquiryProcessor(IMapper autoMapper, ITransactionTypeByIdDataProcessor dataProcessor)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
		}

		public TransactionType GetTransactionTypeById(TransactionTypeValue transactionTypeId)
		{
			var transactionTypeEntity = _dataProcessor.GetTransactionTypeById(transactionTypeId);

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
