using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IAllTasksInquiryProcessor
	{
		PagedDataInquiryResponse<Task> GetTasks(PagedDataRequest requestInfo);
	}
}
