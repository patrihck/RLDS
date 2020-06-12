using Microsoft.AspNetCore.Http;
using RldsApp.Data;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IPagedDataRequestFactory
	{
		PagedDataRequest Create(HttpContext httpContext);
	}
}
