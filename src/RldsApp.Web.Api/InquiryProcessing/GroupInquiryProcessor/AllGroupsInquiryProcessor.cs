using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.GroupDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedGroupDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.Group>;

namespace RldsApp.Web.Api.InquiryProcessing.GroupInquiryProcessor
{
	public class AllGroupsInquiryProcessor : IAllGroupsInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllGroupsDataProcessor _dataProcessor;
		private readonly IGroupLinkService _groupLinkService;

		public AllGroupsInquiryProcessor(IMapper autoMapper, IAllGroupsDataProcessor dataProcessor, IGroupLinkService groupLinkService, ICommonLinkService commonLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_groupLinkService = groupLinkService;
			_commonLinkService = commonLinkService;
		}

		public PagedGroupDataInquiryResponse GetGroups(PagedDataRequest requestInfo)
		{
			var queryResult = _dataProcessor.GetGroups(requestInfo);
			var groups = GetGroups(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedGroupDataInquiryResponse
			{
				Items = groups,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);
			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedGroupDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_groupLinkService.GetAllGroupsLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<Group> GetGroups(IEnumerable<Data.Entities.Group> groupEntities)
		{
			var groups = groupEntities.Select(x => _autoMapper.Map<Group>(x)).ToList();

			groups.ForEach(x =>
			{
				_groupLinkService.AddSelfLink(x);
			});

			return groups;
		}

		public virtual string GetCurrentPageQueryString(PagedGroupDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedGroupDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedGroupDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
