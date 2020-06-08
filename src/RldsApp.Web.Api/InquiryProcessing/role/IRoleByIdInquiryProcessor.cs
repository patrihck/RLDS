using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IRoleByIdInquiryProcessor
	{
		Role GetRoleById(long roleId);
	}
}
