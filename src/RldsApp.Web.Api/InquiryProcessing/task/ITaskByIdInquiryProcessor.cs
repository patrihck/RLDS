using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
    public interface ITaskByIdInquiryProcessor
    {
        Task GetTaskById(long taskId);
    }
}
