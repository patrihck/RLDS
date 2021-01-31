using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public interface IAllTransactionStatusesInquiryProcessor
	{
		PagedDataInquiryResponse<TransactionStatus> GetTransactionTypes(PagedDataRequest requestInfo);
	}
}
