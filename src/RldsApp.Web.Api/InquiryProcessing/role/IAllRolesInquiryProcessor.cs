using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IAllRolesInquiryProcessor
	{
		PagedDataInquiryResponse<Role> GetRoles(PagedDataRequest requestInfo); 
	}
}
