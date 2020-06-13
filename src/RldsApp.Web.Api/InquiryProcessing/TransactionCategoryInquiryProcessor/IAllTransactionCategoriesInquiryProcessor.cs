using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IAllTransactionCategoriesInquiryProcessor
	{
		PagedDataInquiryResponse<TransactionCategory> GetTransactionCategories(PagedDataRequest request);
	}
}
