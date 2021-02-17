using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Common;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedAccountDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.Account>;

namespace RldsApp.Web.Api.InquiryProcessing.AccountInquiryProcessor
{
	public class AllAccountsByUserIdInquiryProcessor : IAllAccountsByUserIdInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly IAllAccountsByUserIdDataProcessor _dataProcessor;
		private readonly IAccountLinkService _accountLinkService;
		private readonly ICommonLinkService _commonLinkService;

		public AllAccountsByUserIdInquiryProcessor(IMapper autoMapper, IAllAccountsByUserIdDataProcessor dataProcessor, IAccountLinkService accountLinkService, ICommonLinkService commonLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_accountLinkService = accountLinkService;
			_commonLinkService = commonLinkService;
		}


		public PagedAccountDataInquiryResponse GetAccountsByUserId(PagedDataRequest requestInfo, long userId)
		{
			var queryResult = _dataProcessor.GetAccountsByUserId(requestInfo, userId);
			var accounts = GetAccountModels(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedAccountDataInquiryResponse
			{
				Items = accounts,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);

			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedAccountDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_accountLinkService.GetAllAccountsLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<Account> GetAccountModels(IEnumerable<Data.Entities.Account> accountEntities)
		{
			var accounts = accountEntities.Select(x => _autoMapper.Map<Account>(x)).ToList();

			accounts.ForEach(x =>
			{
				_accountLinkService.AddSelfLink(x);
				_accountLinkService.AddLinksToChildObjects(x);
			});

			return accounts;
		}

		public virtual string GetCurrentPageQueryString(PagedAccountDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedAccountDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedAccountDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
