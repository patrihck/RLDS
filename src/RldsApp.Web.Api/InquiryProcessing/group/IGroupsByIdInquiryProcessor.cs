using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IGroupByIdInquiryProcessor
	{
		Group GetGroupById(long userId);
	}
}
