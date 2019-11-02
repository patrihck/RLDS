using RldsApp.Data;
using Microsoft.AspNetCore.Http;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IPagedDataRequestFactory
	{
		PagedDataRequest Create(HttpContext httpContext);
	}
}
