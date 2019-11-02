using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
    public interface ITaskLinkService
    {
        Link GetAllTasksLink();
        void AddSelfLink(Task task);
        void AddLinksToChildObjects(Task task);
    }
}
