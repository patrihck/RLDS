using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.GroupInquiryProcessor
{
	public interface IAllGroupsInquiryProcessor
	{
		PagedDataInquiryResponse<Group> GetGroups(PagedDataRequest requestInfo);
	}
}
