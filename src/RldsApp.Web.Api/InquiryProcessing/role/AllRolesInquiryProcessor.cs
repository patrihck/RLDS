using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using System.Collections.Generic;
using System.Linq;
using RldsApp.Data.DataProcessing.role;
using PagedRoleDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.Role>;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class AllRolesInquiryProcessor : IAllRolesInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllRolesDataProcessor _dataProcessor;
		private readonly IRoleLinkService _roleLinkService;

		public AllRolesInquiryProcessor(IMapper autoMapper, IAllRolesDataProcessor dataProcessor, IRoleLinkService roleLinkService, ICommonLinkService commonLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_roleLinkService = roleLinkService;
			_commonLinkService = commonLinkService;
		}

		public PagedRoleDataInquiryResponse GetRoles(PagedDataRequest requestInfo)
		{
			var queryResult = _dataProcessor.GetRoles(requestInfo);
			var roles = GetRoles(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedRoleDataInquiryResponse
			{
				Items = roles,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);
			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedRoleDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_roleLinkService.GetAllRolesLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<Role> GetRoles(IEnumerable<Data.Entities.Role> roleEntities)
		{
			var roles = roleEntities.Select(x => _autoMapper.Map<Role>(x)).ToList();

			roles.ForEach(x =>
			{
				_roleLinkService.AddSelfLink(x);			
			});

			return roles;
		}

		public virtual string GetCurrentPageQueryString(PagedRoleDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedRoleDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedRoleDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
