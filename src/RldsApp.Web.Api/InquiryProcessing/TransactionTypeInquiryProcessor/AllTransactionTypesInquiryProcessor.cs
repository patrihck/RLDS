using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.TransactionTypeDataProcessor;
using RldsApp.Web.Api.Models;
using PagedTransactionTypeDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.TransactionType>;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionTypeInquiryProcessor
{
	public class AllTransactionTypesInquiryProcessor : IAllTransactionTypesInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAllTransactionTypesDataProcessor _dataProcessor;

		public AllTransactionTypesInquiryProcessor(IMapper autoMapper, IAllTransactionTypesDataProcessor dataProcessor)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
		}

		public PagedTransactionTypeDataInquiryResponse GetTransactionTypes(PagedDataRequest requestInfo)
		{
			var queryResult = _dataProcessor.GetTransactionTypes(requestInfo);
			var transactionTypes = GetMappedTransactionTypes(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedTransactionTypeDataInquiryResponse
			{
				Items = transactionTypes,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			return inquiryResponse;
		}

		public virtual IEnumerable<TransactionType> GetMappedTransactionTypes(IEnumerable<Data.Entities.TransactionType> transactionTypeEntities)
		{
			var transactionTypes = transactionTypeEntities.Select(x => _autoMapper.Map<TransactionType>(x)).ToList();
			return transactionTypes;
		}
	}
}
