using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionTypeInquiryProcessor
{
	public interface ITransactionTypeByNameInquiryProcessor
	{
		TransactionType GetTransactionTypeByName(string transactionName);
	}
}
