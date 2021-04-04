using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IUserByNameInquiryProcessor
	{
		User GetUserByName(string name);
	}
}
