using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.MaintenanceProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserByIdInquiryProcessor _userByIdInquiryProcessor;
		private readonly IUserByNameInquiryProcessor _userByNameInquiryProcessor;
		private readonly IAllUsersInquiryProcessor _allUsersInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddUserMaintenanceProcessor _addUserMaintenanceProcessor;
		private readonly IDeleteUserDataProcessor _deleteUserDataProcessor;
		private readonly IUpdateUserMaintenanceProcessor _updateUserMaintenanceProcessor;
		private readonly IAuthenticateUserMaintenanceProcessor _authenticateUserMaintenanceProcessor;

		public UsersController(IUserByIdInquiryProcessor userByIdInquiryProcessor, IUserByNameInquiryProcessor userByNameInquiryProcessor, IAllUsersInquiryProcessor allUsersInquiryProcessor, IPagedDataRequestFactory pagedDataRequestFactory, IAddUserMaintenanceProcessor addUserMaintenanceProcessor, IDeleteUserDataProcessor deleteUserDataProcessor, IUpdateUserMaintenanceProcessor updateUserMaintenanceProcessor, IAuthenticateUserMaintenanceProcessor authenticateUserMaintenanceProcessor)
		{
			_userByIdInquiryProcessor = userByIdInquiryProcessor;
			_userByNameInquiryProcessor = userByNameInquiryProcessor;
			_allUsersInquiryProcessor = allUsersInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addUserMaintenanceProcessor = addUserMaintenanceProcessor;
			_deleteUserDataProcessor = deleteUserDataProcessor;
			_updateUserMaintenanceProcessor = updateUserMaintenanceProcessor;
			_authenticateUserMaintenanceProcessor = authenticateUserMaintenanceProcessor;
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<User> GetUsers()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allUsersInquiryProcessor.GetUsers(request);
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public User GetUserById(long id)
		{
			return _userByIdInquiryProcessor.GetUserById(id);
		}

		[HttpGet("{name}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public User GetUserByName(string name)
		{
			return _userByNameInquiryProcessor.GetUserByName(name);
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public ActionResult<User> RegisterUser(NewUser newUser)
		{
			var user = _addUserMaintenanceProcessor.AddUser(newUser);
			object routeValues = new
			{
				id = user.Id
			};
			return CreatedAtAction(nameof(GetUserById), routeValues, user);
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<User> AddUser(NewUser newUser)
		{
			var user = _addUserMaintenanceProcessor.AddUser(newUser);
			object routeValues = new
			{
				id = user.Id
			};
			return CreatedAtAction(nameof(GetUserById), routeValues, user);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public User UpdateUser(long id, [FromBody] object updatedUser)
		{
			return _updateUserMaintenanceProcessor.UpdateUser(id, updatedUser);
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteUser(long id)
		{
			if (_deleteUserDataProcessor.DeleteUser(id))
			{
				return Ok();
			}
			return NotFound();
		}

		[HttpPost("authenticate")]
		[AllowAnonymous]
		public AuthenticatedData AuthenticateUser(LoginData loginData)
		{
			return _authenticateUserMaintenanceProcessor.AuthenticateUser(loginData);
		}
	}
}
