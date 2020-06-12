using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
	public interface ITransactionByIdInquiryProcessor
	{
		Transaction GetTransactionById(long transactionId);
	}
}
