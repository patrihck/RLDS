using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RoleInquiryProcessor
{
	public interface IRoleByNameInquiryProcessor
	{
		Role GetRoleByName(string roleName);
	}
}
