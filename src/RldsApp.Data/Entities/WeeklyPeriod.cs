namespace RldsApp.Data.Entities
{
    public class WeeklyPeriod : RecurringRule
	{
		public virtual bool IsMonday { get; set; }
		public virtual bool IsTuesday { get; set; }
		public virtual bool IsWednesday { get; set; }
		public virtual bool IsThursday { get; set; }
		public virtual bool IsFriday { get; set; }
		public virtual bool IsSaturday { get; set; }
		public virtual bool IsSunday { get; set; }
	}
}
