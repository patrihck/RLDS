using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class WeeklyPeriodMap : VersionedClassMap<WeeklyPeriod>
	{
		public WeeklyPeriodMap()
		{
			Id(x => x.Id, "WeeklyPeriodId");
			Map(x => x.IsActive).Not.Nullable();
			Map(x => x.StartDate).Nullable();
			Map(x => x.EndDate).Nullable();
			Map(x => x.IsMonday).Nullable();
			Map(x => x.IsTuesday).Nullable();
			Map(x => x.IsWednesday).Nullable();
			Map(x => x.IsThursday).Nullable();
			Map(x => x.IsFriday).Nullable();
			Map(x => x.IsSaturday).Nullable();
			Map(x => x.IsSunday).Nullable();
		}
	}
}
