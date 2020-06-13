using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RoleInquiryProcessor
{
	public interface IRoleByIdInquiryProcessor
	{
		Role GetRoleById(long roleId);
	}
}
