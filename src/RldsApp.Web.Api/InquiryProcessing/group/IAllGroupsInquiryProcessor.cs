using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IAllGroupsInquiryProcessor
	{
		PagedDataInquiryResponse<Group> GetGroups(PagedDataRequest requestInfo); 
	}
}
