using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
    public class StatusMap : VersionedClassMap<TaskStatus>
    {
        public StatusMap()
        {
            Id(x => x.TaskStatusId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Ordinal).Not.Nullable();
        }
    }
}
