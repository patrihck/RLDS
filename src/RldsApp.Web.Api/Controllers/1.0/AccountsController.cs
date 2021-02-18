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
			var accounts = _allAccountsInquiryProcessor.GetAccounts(request);

			return accounts;
		}

		[HttpGet("GetAccountsByUserId/{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<Account> GetAccountsByUserId(long id)
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var accounts = _allAccountsByUserIdInquiryProcessor.GetAccountsByUserId(request, id);

			return accounts;
		}

		[HttpGet("{id:long}")]
		public Account GetAccountById(long id)
		{
			var account = _accountByIdInquiryProcessor.GetAccountById(id);

			return account;
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<Account> AddAccount(NewAccount newAccount)
		{
			var account = _addAccountMaintenanceProcessor.AddAccount(newAccount);

			return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Account UpdateAccount(long id, [FromBody] object updatedAccount)
		{
			var account = _updateAccountMaintenanceProcessor.UpdateAccount(id, updatedAccount);

			return account;
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
