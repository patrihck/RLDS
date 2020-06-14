using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IAllUsersInquiryProcessor
	{
		PagedDataInquiryResponse<User> GetUsers(PagedDataRequest requestInfo);
	}
}
