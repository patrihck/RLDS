using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionTypeInquiryProcessor
{
	public interface IAllTransactionTypesInquiryProcessor
	{
		PagedDataInquiryResponse<TransactionType> GetTransactionTypes(PagedDataRequest requestInfo);
	}
}
