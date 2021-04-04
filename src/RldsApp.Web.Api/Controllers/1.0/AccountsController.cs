using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.AccountInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.AccountMaintenanceProcessor;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountByIdInquiryProcessor _accountByIdInquiryProcessor;
		private readonly IAllAccountsInquiryProcessor _allAccountsInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddAccountMaintenanceProcessor _addAccountMaintenanceProcessor;
		private readonly IDeleteAccountMaintenanceProcessor _deleteAccountMaintenanceProcessor;
		private readonly IUpdateAccountMaintenanceProcessor _updateAccountMaintenanceProcessor;
		private readonly IAllAccountsByUserIdInquiryProcessor _allAccountsByUserIdInquiryProcessor;

		public AccountsController(
			IAccountByIdInquiryProcessor accountByIdInquiryProcessor,
			IAllAccountsInquiryProcessor allAccountsInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory,
			IAddAccountMaintenanceProcessor addAccountMaintenanceProcessor,
			IDeleteAccountMaintenanceProcessor deleteAccountMaintenanceProcessor,
			IUpdateAccountMaintenanceProcessor updateAccountDataProcessor,
			IAllAccountsByUserIdInquiryProcessor allAccountsByUserIdInquiryProcessor)
		{
			_accountByIdInquiryProcessor = accountByIdInquiryProcessor;
			_allAccountsInquiryProcessor = allAccountsInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addAccountMaintenanceProcessor = addAccountMaintenanceProcessor;
			_deleteAccountMaintenanceProcessor = deleteAccountMaintenanceProcessor;
			_updateAccountMaintenanceProcessor = updateAccountDataProcessor;
			_allAccountsByUserIdInquiryProcessor = allAccountsByUserIdInquiryProcessor;
		}

		[HttpGet]
		public PagedDataInquiryResponse<Account> GetAccount()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allAccountsInquiryProcessor.GetAccounts(request);
		}

		[HttpGet("GetAccountsByUserId/{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<Account> GetAccountsByUserId(long id)
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allAccountsByUserIdInquiryProcessor.GetAccountsByUserId(request, id);
		}

		[HttpGet("{id:long}")]
		public Account GetAccountById(long id)
		{
			return _accountByIdInquiryProcessor.GetAccountById(id);
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<Account> AddAccount(NewAccount newAccount)
		{
			var account = _addAccountMaintenanceProcessor.AddAccount(newAccount);
			object routeValues = new
			{
				id = account.Id
			};
			return CreatedAtAction(nameof(GetAccountById), routeValues, account);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Account UpdateAccount(long id, [FromBody] object updatedAccount)
		{
			return _updateAccountMaintenanceProcessor.UpdateAccount(id, updatedAccount);
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteAccount(long id)
		{
			if (_deleteAccountMaintenanceProcessor.DeleteAccount(id))
			{
				return Ok();
			}
			return NotFound();
		}
	}
}
