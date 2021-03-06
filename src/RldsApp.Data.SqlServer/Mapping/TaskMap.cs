using FluentNHibernate.Mapping;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class TaskMap : VersionedClassMap<Task>
	{
		public TaskMap()
		{
			Id(x => x.Id, "TaskId");
			Map(x => x.Subject).Not.Nullable();
			Map(x => x.StartDate).Nullable();
			Map(x => x.DueDate).Nullable();
			Map(x => x.CompletedDate).Nullable();
			Map(x => x.CreatedDate).Not.Nullable();

			References(x => x.Status, "StatusId");
			References(x => x.CreatedBy, "CreatedUserId");

			HasManyToMany(x => x.Assignees)
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Table("TaskUser")
				.ParentKeyColumn("TaskId")
				.ChildKeyColumn("UserId");
		}
	}
}
