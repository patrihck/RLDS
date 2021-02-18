using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class TransactionsController : ControllerBase
	{
		private readonly ITransactionByIdInquiryProcessor _transactionByIdInquiryProcessor;
		private readonly IAllTransactionsInquiryProcessor _allTransactionsInquiryProcessor;
		private readonly IAllTransactionsByAccountIdInquiryProcessor _allTransactionsByAccountIdInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddTransactionMaintenanceProcessor _addTransactionMaintenanceProcessor;
		private readonly IUpdateTransactionMaintenanceProcessor _updateTransactionMaintenanceProcessor;
		private readonly IDeleteTransactionMaintenanceProcessor _deleteTransactionDataProcessor;
		

		public TransactionsController(
			ITransactionByIdInquiryProcessor transactionByIdInquiryProcessor,
			IAllTransactionsInquiryProcessor allTransactionsInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory,
			IAddTransactionMaintenanceProcessor addTransactionMaintenanceProcessor,
			IUpdateTransactionMaintenanceProcessor updateTransactionMaintenanceProcessor,
			IDeleteTransactionMaintenanceProcessor deleteTransactionDataProcessor,
			IAllTransactionsByAccountIdInquiryProcessor allTransactionsByAccountIdInquiryProcessor)
		{
			_transactionByIdInquiryProcessor = transactionByIdInquiryProcessor;
			_allTransactionsInquiryProcessor = allTransactionsInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addTransactionMaintenanceProcessor = addTransactionMaintenanceProcessor;
			_updateTransactionMaintenanceProcessor = updateTransactionMaintenanceProcessor;
			_deleteTransactionDataProcessor = deleteTransactionDataProcessor;
			_allTransactionsByAccountIdInquiryProcessor = allTransactionsByAccountIdInquiryProcessor;
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Transaction GetTransactionById(long id)
		{
			var transaction = _transactionByIdInquiryProcessor.GetTransactionById(id);
			return transaction;
		}

		[HttpGet("GetTransactionsByAccountId/{id:long}")]
		public PagedDataInquiryResponse<Transaction> GetTransactionsByAccountId(long id)
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var transactions = _allTransactionsByAccountIdInquiryProcessor.GetAllTransactionsByAccountId(request, id);

			return transactions;
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<Transaction> GetTransactions()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var transactions = _allTransactionsInquiryProcessor.GetTransactions(request);

			return transactions;
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<Transaction> AddTransaction(NewTransaction newTransaction)
		{
			var transaction = _addTransactionMaintenanceProcessor.AddTransaction(newTransaction);
			return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
		}

		[HttpPut("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<Transaction> UpdateTransaction(long id, [FromBody] object updatedTransaction)
		{
			var transaction = _updateTransactionMaintenanceProcessor.UpdateTransaction(id, updatedTransaction);
			return transaction;
		}

		[HttpDelete("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteTransaction(long id)
		{
			if (_deleteTransactionDataProcessor.DeleteTransaction(id))
			{
				return Ok();
			}

			return NotFound();
		}
	}
}
