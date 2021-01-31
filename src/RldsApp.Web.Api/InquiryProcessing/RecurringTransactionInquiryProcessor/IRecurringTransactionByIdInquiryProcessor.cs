using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public interface IRecurringTransactionByIdInquiryProcessor
	{
		RecurringTransaction GetRecurringTransactionById(long recurringTransactionId);
	}
}
