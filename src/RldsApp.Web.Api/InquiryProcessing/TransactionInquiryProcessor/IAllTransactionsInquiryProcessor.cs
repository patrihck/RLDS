using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
	public interface IAllTransactionsInquiryProcessor
	{
		PagedDataInquiryResponse<Transaction> GetTransactions(PagedDataRequest requestInfo);
	}
}
