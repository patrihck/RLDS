using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Data.Entities
{
	public class RecurringRule : IVersionedEntity
	{
		private readonly IList<DailyPeriod> _dailyPeriods = new List<DailyPeriod>();
		private readonly IList<WeeklyPeriod> _weeklyPeriods = new List<WeeklyPeriod>();
		private readonly IList<MonthlyPeriod> _monthlyPeriods = new List<MonthlyPeriod>();

		[Key]
		public virtual long Id { get; set; }
		public virtual User User { get; set; }
		public virtual Account Sender { get; set; }
		public virtual Account Receiver { get; set; }
		public virtual TransactionType Type { get; set; }
		public virtual TransactionCategory Category { get; set; }
		public virtual Currency Currency { get; set; }
		public virtual string Description { get; set; }
		public virtual decimal Amount { get; set; }
		public virtual IList<DailyPeriod> DailyPeriods => _dailyPeriods;
		public virtual IList<WeeklyPeriod> WeeklyPeriods => _weeklyPeriods;
		public virtual IList<MonthlyPeriod> MonthlyPeriods => _monthlyPeriods;
		public virtual bool IsActive { get; set; }
		public virtual DateTime? StartDate { get; set; }
		public virtual DateTime? EndDate { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
