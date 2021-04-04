using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class DailyPeriodMap : VersionedClassMap<DailyPeriod>
	{
		public DailyPeriodMap()
		{
			Id(x => x.Id, "DailyPeriodId");
			Map(x => x.IsActive).Not.Nullable();
			Map(x => x.StartDate).Nullable();
			Map(x => x.EndDate).Nullable();
		}
	}
}
