using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.MaintenanceProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
		private readonly IRoleByIdInquiryProcessor _userByIdInquiryProcessor;
		private readonly IAllRolesInquiryProcessor _allRolesInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddRoleMaintenanceProcessor _addRoleMaintenanceProcessor;
		private readonly IDeleteRoleDataProcessor _deleteRoleDataProcessor;
		private readonly IUpdateRoleMaintenanceProcessor _updateRoleMaintenanceProcessor;
		

		public RolesController(IRoleByIdInquiryProcessor userByIdInquiryProcessor, IAllRolesInquiryProcessor allRolesInquiryProcessor, IPagedDataRequestFactory pagedDataRequestFactory, IAddRoleMaintenanceProcessor addRoleMaintenanceProcessor, IDeleteRoleDataProcessor deleteRoleDataProcessor, IUpdateRoleMaintenanceProcessor updateRoleMaintenanceProcessor)
		{
			_userByIdInquiryProcessor = userByIdInquiryProcessor;
			_allRolesInquiryProcessor = allRolesInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;	
			_addRoleMaintenanceProcessor = addRoleMaintenanceProcessor;
			_deleteRoleDataProcessor = deleteRoleDataProcessor;
			_updateRoleMaintenanceProcessor = updateRoleMaintenanceProcessor;
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<Role> GetRoles()
        {
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var users = _allRolesInquiryProcessor.GetRoles(request);

			return users;
		}

        [HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
        public Role GetRoleById(long id)
        {
			var user = _userByIdInquiryProcessor.GetRoleById(id);
			return user;
		}


		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<Role> AddRole(NewRole newRole)
        {
			var user = _addRoleMaintenanceProcessor.AddRole(newRole);
			return CreatedAtAction(nameof(GetRoleById), new { id = user.RoleId }, user);
		}

        [HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Role UpdateRole(long id, [FromBody] object updatedRole)
        {
			var user = _updateRoleMaintenanceProcessor.UpdateRole(id, updatedRole);
			return user;
		}

        [HttpDelete("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteRole(long id)
        {
			if (_deleteRoleDataProcessor.DeleteRole(id))
			{
				return Ok();
			}
			
			return NoContent();
        }


	}
}
