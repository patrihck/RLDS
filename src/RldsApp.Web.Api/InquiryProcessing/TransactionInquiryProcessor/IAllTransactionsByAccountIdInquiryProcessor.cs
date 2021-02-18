using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
	public interface IAllTransactionsByAccountIdInquiryProcessor
	{
		PagedDataInquiryResponse<Transaction> GetAllTransactionsByAccountId(PagedDataRequest requestInfo, long accountId);
	}
}
