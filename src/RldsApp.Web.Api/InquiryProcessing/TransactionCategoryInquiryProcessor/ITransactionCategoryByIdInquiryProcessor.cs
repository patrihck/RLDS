using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface ITransactionCategoryByIdInquiryProcessor
	{
		TransactionCategory GetTransactionCategoryById(long transactionCategoryId);
	}
}
