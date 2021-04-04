using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.RoleInquiryProcessor;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers._1._0
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class RolesController : ControllerBase
	{
		private readonly IRoleByIdInquiryProcessor _roleByIdInquiryProcessor;
		private readonly IRoleByNameInquiryProcessor _roleByNameInquiryProcessor;
		private readonly IAllRolesInquiryProcessor _allRolesInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

		public RolesController(IRoleByIdInquiryProcessor roleByIdInquiryProcessor, IRoleByNameInquiryProcessor roleByNameInquiryProcessor,
			IAllRolesInquiryProcessor allRolesInquiryProcessor, IPagedDataRequestFactory pagedDataRequestFactory)
		{
			_roleByIdInquiryProcessor = roleByIdInquiryProcessor;
			_roleByNameInquiryProcessor = roleByNameInquiryProcessor;
			_allRolesInquiryProcessor = allRolesInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
		}

		[HttpGet]
		public PagedDataInquiryResponse<Role> GetRoles()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allRolesInquiryProcessor.GetRoles(request);
		}

		[HttpGet("{roleId:long}")]
		public Role GetRoleById(long roleId)
		{
			return _roleByIdInquiryProcessor.GetRoleById(roleId);
		}

		[HttpGet("{roleName}")]
		public Role GetRoleByName(string roleName)
		{
			return _roleByNameInquiryProcessor.GetRoleByName(roleName);
		}
	}
}
