using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.MaintenanceProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
		private readonly IGroupByIdInquiryProcessor _groupByIdInquiryProcessor;
		private readonly IAllGroupsInquiryProcessor _allGroupsInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddGroupMaintenanceProcessor _addGroupMaintenanceProcessor;
		private readonly IDeleteGroupDataProcessor _deleteGroupDataProcessor;
		private readonly IUpdateGroupMaintenanceProcessor _updateGroupMaintenanceProcessor;

		public GroupsController(IGroupByIdInquiryProcessor groupByIdInquiryProcessor, IAllGroupsInquiryProcessor allGroupsInquiryProcessor, IPagedDataRequestFactory pagedDataRequestFactory, IAddGroupMaintenanceProcessor addGroupMaintenanceProcessor, IDeleteGroupDataProcessor deleteGroupDataProcessor, IUpdateGroupMaintenanceProcessor updateGroupMaintenanceProcessor)
		{
			_groupByIdInquiryProcessor = groupByIdInquiryProcessor;
			_allGroupsInquiryProcessor = allGroupsInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addGroupMaintenanceProcessor = addGroupMaintenanceProcessor;
			_deleteGroupDataProcessor = deleteGroupDataProcessor;
			_updateGroupMaintenanceProcessor = updateGroupMaintenanceProcessor;
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<Group> GetGroups()
        {
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var groups = _allGroupsInquiryProcessor.GetGroups(request);

			return groups;
		}

        [HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
        public Group GetGroupById(long id)
        {
			var group = _groupByIdInquiryProcessor.GetGroupById(id);
			return group;
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<Group> AddGroup(NewGroup newGroup)
        {
			var group = _addGroupMaintenanceProcessor.AddGroup(newGroup);
			return CreatedAtAction(nameof(GetGroupById), new { id = group.GroupId }, group);
		}

        [HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Group UpdateGroup(long id, [FromBody] object updatedGroup)
        {
			var group = _updateGroupMaintenanceProcessor.UpdateGroup(id, updatedGroup);
			return group;
		}

        [HttpDelete("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteGroup(long id)
        {
			if (_deleteGroupDataProcessor.DeleteGroup(id))
			{
				return Ok();
			}
			
			return NoContent();
        }

	}
}
