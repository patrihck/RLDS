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
			var users = _allUsersInquiryProcessor.GetUsers(request);

			return users;
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public User GetUserById(long id)
		{
			var user = _userByIdInquiryProcessor.GetUserById(id);
			return user;
		}

		[HttpGet("{name}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public User GetUserByName(string name)
		{
			var user = _userByNameInquiryProcessor.GetUserByName(name);
			return user;
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public ActionResult<User> RegisterUser(NewUser newUser)
		{
			var user = _addUserMaintenanceProcessor.AddUser(newUser);
			return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<User> AddUser(NewUser newUser)
		{
			var user = _addUserMaintenanceProcessor.AddUser(newUser);
			return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public User UpdateUser(long id, [FromBody] object updatedUser)
		{
			var user = _updateUserMaintenanceProcessor.UpdateUser(id, updatedUser);
			return user;
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
			var authenticatedData = _authenticateUserMaintenanceProcessor.AuthenticateUser(loginData);
			return authenticatedData;
		}
	}
}
