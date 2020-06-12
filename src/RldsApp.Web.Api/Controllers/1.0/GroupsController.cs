using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.GroupInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.GroupMaintenanceProcessor;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class GroupsController : ControllerBase
	{
		private readonly IGroupByIdInquiryProcessor _groupByIdInquiryProcessor;
		private readonly IAllGroupsInquiryProcessor _allGroupsInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddGroupMaintenanceProcessor _addGroupMaintenanceProcessor;
		private readonly IUpdateGroupMaintenanceProcessor _updateGroupMaintenanceProcessor;
		private readonly IDeleteGroupMaintenanceProcessor _deleteGroupMaintenanceProcessor;
		

		public GroupsController(IGroupByIdInquiryProcessor groupByIdInquiryProcessor, IAllGroupsInquiryProcessor allGroupsInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory, IAddGroupMaintenanceProcessor addGroupMaintenanceProcessor,
			IUpdateGroupMaintenanceProcessor updateGroupMaintenanceProcessor, IDeleteGroupMaintenanceProcessor deleteGroupMaintenanceProcessor)
		{
			_groupByIdInquiryProcessor = groupByIdInquiryProcessor;
			_allGroupsInquiryProcessor = allGroupsInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addGroupMaintenanceProcessor = addGroupMaintenanceProcessor;
			_updateGroupMaintenanceProcessor = updateGroupMaintenanceProcessor;
			_deleteGroupMaintenanceProcessor = deleteGroupMaintenanceProcessor;
		}

		[HttpGet]
		public PagedDataInquiryResponse<Group> GetGroup()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var groups = _allGroupsInquiryProcessor.GetGroups(request);

			return groups;
		}

		[HttpGet("{groupId:long}")]
		public Group GetGroupById(long groupId)
		{
			var group = _groupByIdInquiryProcessor.GetGroupById(groupId);
			return group;
		}

		[HttpPost]
		public ActionResult<Group> AddGroup(NewGroup newGroup)
		{
			var group = _addGroupMaintenanceProcessor.AddGroup(newGroup);

			return CreatedAtAction(nameof(GetGroupById), new
			{
				groupId = group.Id
			}, group);
		}

		[HttpPut("{groupId:long}")]
		public Group UpdateGroup(long groupId, [FromBody] object updatedGroup)
		{
			var group = _updateGroupMaintenanceProcessor.UpdateGroup(groupId, updatedGroup);

			return group;
		}

		[HttpDelete("{groupId:long}")]
		public ActionResult DeleteGroup(long groupId)
		{
			if (_deleteGroupMaintenanceProcessor.DeleteGroup(groupId))
			{
				return Ok();
			}

			return NoContent();
		}
	}
}
