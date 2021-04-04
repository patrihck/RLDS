using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
	public class MonthlyPeriodMap : VersionedClassMap<MonthlyPeriod>
	{
		public MonthlyPeriodMap()
		{
			Id(x => x.Id, "MonthlyPeriodId");
			Map(x => x.IsActive).Not.Nullable();
			Map(x => x.StartDate).Nullable();
			Map(x => x.EndDate).Nullable();
			Map(x => x.SelectedDay).Not.Nullable();
		}
	}
}
