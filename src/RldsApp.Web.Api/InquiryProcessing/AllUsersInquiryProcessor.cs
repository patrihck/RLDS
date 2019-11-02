using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using System.Collections.Generic;
using System.Linq;
using PagedUserDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.User>;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class AllUsersInquiryProcessor : IAllUsersInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllUsersDataProcessor _dataProcessor;
		private readonly IUserLinkService _userLinkService;

		public AllUsersInquiryProcessor(IMapper autoMapper, IAllUsersDataProcessor dataProcessor, IUserLinkService userLinkService, ICommonLinkService commonLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_userLinkService = userLinkService;
			_commonLinkService = commonLinkService;
		}

		public PagedUserDataInquiryResponse GetUsers(PagedDataRequest requestInfo)
		{
			var queryResult = _dataProcessor.GetUsers(requestInfo);
			var users = GetUsers(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedUserDataInquiryResponse
			{
				Items = users,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);
			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedUserDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_userLinkService.GetAllUsersLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<User> GetUsers(IEnumerable<Data.Entities.User> userEntities)
		{
			var users = userEntities.Select(x => _autoMapper.Map<User>(x)).ToList();

			users.ForEach(x =>
			{
				_userLinkService.AddSelfLink(x);
				_userLinkService.AddLinksToChildObjects(x);
			});

			return users;
		}

		public virtual string GetCurrentPageQueryString(PagedUserDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedUserDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedUserDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
