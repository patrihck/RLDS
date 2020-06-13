using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public interface ITransactionStatusByIdInquiryProcess
	{
		TransactionStatus GetTransactionStatusById(long transactionId);
	}
}
