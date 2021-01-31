using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class RecurringTransactionsController : ControllerBase
	{
		private readonly IRecurringTransactionByIdInquiryProcessor _recurringTransactionByIdInquiryProcessor;
		private readonly IAllRecurringTransactionsInquiryProcessor _allRecurringTransactionsInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddRecurringTransactionMaintenanceProcessor _addRecurringTransactionMaintenanceProcessor;
		private readonly IUpdateRecurringTransactionMaintenanceProcessor _updateRecurringTransactionMaintenanceProcessor;
		private readonly IDeleteRecurringTransactionMaintenanceProcessor _deleteRecurringTransactionDataProcessor;

		public RecurringTransactionsController(
			IRecurringTransactionByIdInquiryProcessor recurringTransactionByIdInquiryProcessor,
			IAllRecurringTransactionsInquiryProcessor allRecurringTransactionsInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory,
			IAddRecurringTransactionMaintenanceProcessor addRecurringTransactionMaintenanceProcessor,
			IUpdateRecurringTransactionMaintenanceProcessor updateRecurringTransactionMaintenanceProcessor,
			IDeleteRecurringTransactionMaintenanceProcessor deleteRecurringTransactionDataProcessor)
		{
			_recurringTransactionByIdInquiryProcessor = recurringTransactionByIdInquiryProcessor;
			_allRecurringTransactionsInquiryProcessor = allRecurringTransactionsInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addRecurringTransactionMaintenanceProcessor = addRecurringTransactionMaintenanceProcessor;
			_updateRecurringTransactionMaintenanceProcessor = updateRecurringTransactionMaintenanceProcessor;
			_deleteRecurringTransactionDataProcessor = deleteRecurringTransactionDataProcessor;
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public RecurringTransaction GetRecurringTransactionById(long id)
		{
			return _recurringTransactionByIdInquiryProcessor.GetRecurringTransactionById(id);
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<RecurringTransaction> GetRecurringTransactions()
		{
			return _allRecurringTransactionsInquiryProcessor.GetRecurringTransactions(
				_pagedDataRequestFactory.Create(HttpContext)
			);
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<RecurringTransaction> AddRecurringTransaction(NewRecurringTransaction newRecurringTransaction)
		{
			var recurringTransaction = _addRecurringTransactionMaintenanceProcessor.AddRecurringTransaction(newRecurringTransaction);
			return CreatedAtAction(
				nameof(GetRecurringTransactionById),
				new {
					id = recurringTransaction.Id
				},
				recurringTransaction
			);
		}

		[HttpPut("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<RecurringTransaction> UpdateRecurringTransaction(
			long id,
			[FromBody] object updatedRecurringTransaction)
		{
			return _updateRecurringTransactionMaintenanceProcessor.UpdateRecurringTransaction(
				id, updatedRecurringTransaction
			);
		}

		[HttpDelete("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteRecurringTransaction(long id)
		{
			if (_deleteRecurringTransactionDataProcessor.DeleteTransaction(id))
				return Ok();
				
			return NotFound();
		}
	}
}
