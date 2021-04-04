using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public interface IRecurringRuleByIdInquiryProcessor
	{
		RecurringRule GetRecurringRuleById(long recurringRuleId);
	}
}
