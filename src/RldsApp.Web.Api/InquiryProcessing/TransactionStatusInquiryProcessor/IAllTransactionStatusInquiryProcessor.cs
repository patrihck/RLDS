using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public interface IAllTransactionStatusInquiryProcessor
	{
		PagedDataInquiryResponse<TransactionStatus> GetTransactionsStatus(PagedDataRequest requestInfo);
	}
}
