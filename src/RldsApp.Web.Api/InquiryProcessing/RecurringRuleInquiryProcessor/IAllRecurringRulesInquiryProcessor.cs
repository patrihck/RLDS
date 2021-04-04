using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public interface IAllRecurringRulesInquiryProcessor
	{
		PagedDataInquiryResponse<RecurringRule> GetRecurringRules(PagedDataRequest requestInfo);
	}
}
