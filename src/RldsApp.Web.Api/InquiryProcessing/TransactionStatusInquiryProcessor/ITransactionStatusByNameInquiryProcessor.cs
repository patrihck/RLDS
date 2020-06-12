using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public interface ITransactionStatusByNameInquiryProcessor
	{
		TransactionStatus GetTransactionStatusByName(string statusName);
	}
}
