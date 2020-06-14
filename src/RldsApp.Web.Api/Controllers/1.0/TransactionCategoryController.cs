using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.MaintenanceProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/transaction-categories")]
	[ApiController]
	public class TransactionCategoryController : ControllerBase
	{
		private readonly IAddTransactionCategoryMaintenanceProcessor _addTransactionCategoryMaintenanceProcessor;
		private readonly IAllTransactionCategoriesInquiryProcessor _allTransactionCategoriesInquiryProcessor;
		private readonly IDeleteTransactionCategoryMaintenanceProcessor _deleteTransactionCategoryDataProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly ITransactionCategoryByIdInquiryProcessor _transactionCategoryByIdInquiryProcessor;
		private readonly IUpdateTransactionCategoryMaintenanceProcessor _updateTransactionCategoryMaintenanceProcessor;

		public TransactionCategoryController(
			ITransactionCategoryByIdInquiryProcessor transactionCategoryByIdInquiryProcessor,
			IAllTransactionCategoriesInquiryProcessor allTransactionCategoriesInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory,
			IAddTransactionCategoryMaintenanceProcessor addTransactionCategoryMaintenanceProcessor,
			IUpdateTransactionCategoryMaintenanceProcessor updateTransactionCategoryMaintenanceProcessor,
			IDeleteTransactionCategoryMaintenanceProcessor deleteTransactionCategoryDataProcessor)
		{
			_transactionCategoryByIdInquiryProcessor = transactionCategoryByIdInquiryProcessor;
			_allTransactionCategoriesInquiryProcessor = allTransactionCategoriesInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addTransactionCategoryMaintenanceProcessor = addTransactionCategoryMaintenanceProcessor;
			_updateTransactionCategoryMaintenanceProcessor = updateTransactionCategoryMaintenanceProcessor;
			_deleteTransactionCategoryDataProcessor = deleteTransactionCategoryDataProcessor;
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<TransactionCategory> AddTransactionCategory(NewTransactionCategory newTransactionCategory)
		{
			var transactionCategory = _addTransactionCategoryMaintenanceProcessor.AddTransactionCategory(newTransactionCategory);
			return CreatedAtAction(nameof(GetTransactionCategoryById), new { id = transactionCategory.Id }, transactionCategory);
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteTransactionCategory(long id)
		{
			if (_deleteTransactionCategoryDataProcessor.DeleteTransactionCategory(id))
			{
				return Ok();
			}

			return NoContent();
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<TransactionCategory> GetTransactionCategories()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var transactionCategories = _allTransactionCategoriesInquiryProcessor.GetTransactionCategories(request);

			return transactionCategories;
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public TransactionCategory GetTransactionCategoryById(long id)
		{
			var transactionCategory = _transactionCategoryByIdInquiryProcessor.GetTransactionCategoryById(id);
			return transactionCategory;
		}

		[HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public TransactionCategory UpdateTransactionCategory(long id, [FromBody] object updatedTransactionCategory)
		{
			var transactionCategory = _updateTransactionCategoryMaintenanceProcessor.UpdateTransactionCategory(id, updatedTransactionCategory);
			return transactionCategory;
		}
	}
}
