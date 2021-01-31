using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public interface IAllRecurringTransactionsInquiryProcessor
	{
		PagedDataInquiryResponse<RecurringTransaction> GetRecurringTransactions(PagedDataRequest requestInfo);
	}
}
