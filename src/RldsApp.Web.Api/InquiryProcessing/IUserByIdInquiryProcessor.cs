using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IUserByIdInquiryProcessor
	{
		User GetUserById(long userId);
	}
}
