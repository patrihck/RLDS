using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class TransactionCategoryByIdInquiryProcessor : ITransactionCategoryByIdInquiryProcessor
	{
		private readonly ITransactionCategoryByIdDataProcessor _dataProcessor;
		private readonly IMapper _automapper;
		private readonly ITransactionCategoryLinkService _linkService;

		public TransactionCategoryByIdInquiryProcessor(ITransactionCategoryByIdDataProcessor dataProcessor, IMapper autoMapper, ITransactionCategoryLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_automapper = autoMapper;
			_linkService = linkService;
		}

		public TransactionCategory GetTransactionCategoryById(long transactionCategoryId)
		{
			var transactionCategoryEntity = _dataProcessor.GetTransactionCategoryById(transactionCategoryId);

			if (transactionCategoryEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.TransactionCategoryNotFound);
			}

			var transactionCategory = GetMappedTransactionCategory(transactionCategoryEntity);
			return transactionCategory;
		}

		public virtual TransactionCategory GetMappedTransactionCategory(Data.Entities.TransactionCategory transactionCategoryEntity)
		{
			var transactionCategory = _automapper.Map<TransactionCategory>(transactionCategoryEntity);
			_linkService.AddSelfLink(transactionCategory);

			return transactionCategory;
		}
	}
}
