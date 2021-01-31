using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public interface ITransactionStatusByIdInquiryProcessor
	{
		TransactionStatus GetTransactionStatusById(TransactionStatusValue transactionId);
	}
}
