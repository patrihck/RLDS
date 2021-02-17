using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.AccountInquiryProcessor
{
	public interface IAllAccountsByUserIdInquiryProcessor
	{
		PagedDataInquiryResponse<Account> GetAccountsByUserId(PagedDataRequest requestInfo,long userId);
	}
}
