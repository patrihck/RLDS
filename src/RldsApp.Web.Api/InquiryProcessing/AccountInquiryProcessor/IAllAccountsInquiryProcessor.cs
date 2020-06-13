using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.AccountInquiryProcessor
{
	public interface IAllAccountsInquiryProcessor
	{
		PagedDataInquiryResponse<Account> GetAccounts(PagedDataRequest requestInfo);
	}
}
