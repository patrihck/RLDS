using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.AccountInquiryProcessor
{
	public interface IAccountByIdInquiryProcessor
	{
		Account GetAccountById(long accountId);
	}
}
