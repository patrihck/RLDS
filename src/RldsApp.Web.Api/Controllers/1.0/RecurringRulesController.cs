using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor;
using RldsApp.Data;
using RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class RecurringRulesController : ControllerBase
	{
		private readonly IRecurringRuleByIdInquiryProcessor _recurringRuleByIdInquiryProcessor;
		private readonly IAllRecurringRulesInquiryProcessor _allRecurringRulesInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddRecurringRuleMaintenanceProcessor _addRecurringRuleMaintenanceProcessor;
		private readonly IUpdateRecurringRuleMaintenanceProcessor _updateRecurringRuleMaintenanceProcessor;
		private readonly IDeleteRecurringRuleMaintenanceProcessor _deleteRecurringRuleDataProcessor;

		public RecurringRulesController(
			IRecurringRuleByIdInquiryProcessor recurringTransactionByIdInquiryProcessor,
			IAllRecurringRulesInquiryProcessor allRecurringTransactionsInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory,
			IAddRecurringRuleMaintenanceProcessor addRecurringRuleMaintenanceProcessor,
			IUpdateRecurringRuleMaintenanceProcessor updateRecurringRuleMaintenanceProcessor,
			IDeleteRecurringRuleMaintenanceProcessor deleteRecurringRuleDataProcessor)
		{
			_recurringRuleByIdInquiryProcessor = recurringTransactionByIdInquiryProcessor;
			_allRecurringRulesInquiryProcessor = allRecurringTransactionsInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addRecurringRuleMaintenanceProcessor = addRecurringRuleMaintenanceProcessor;
			_updateRecurringRuleMaintenanceProcessor = updateRecurringRuleMaintenanceProcessor;
			_deleteRecurringRuleDataProcessor = deleteRecurringRuleDataProcessor;
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public RecurringRule GetRecurringRuleById(long id)
		{
			return _recurringRuleByIdInquiryProcessor.GetRecurringRuleById(id);
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<RecurringRule> GetRecurringRules()
		{
			PagedDataRequest request = _pagedDataRequestFactory.Create(HttpContext);
			return _allRecurringRulesInquiryProcessor.GetRecurringRules(request);
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<RecurringRule> AddRecurringRuleAndPlannedTransactions(NewRecurringRule newRecurringRule)
		{
			var recurringRule = _addRecurringRuleMaintenanceProcessor.AddRecurringRuleAndPlannedTransactions(newRecurringRule);
			object routeValues = new
			{
				id = recurringRule.Id
			};
			return CreatedAtAction(nameof(GetRecurringRuleById), routeValues, recurringRule);
		}

		[HttpPut("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<RecurringRule> UpdateRecurringRule(long id, [FromBody] object updatedRecurringRule)
		{
			return _updateRecurringRuleMaintenanceProcessor.UpdateRecurringRule(id, updatedRecurringRule);
		}

		[HttpDelete("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteRecurringRule(long id)
		{
			if (_deleteRecurringRuleDataProcessor.DeleteRecurringRule(id))
            {
				return Ok();
			}
			return NotFound();
		}
	}
}
