using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.GroupInquiryProcessor
{
	public interface IGroupByIdInquiryProcessor
	{
		Group GetGroupById(long groupId);
	}
}
