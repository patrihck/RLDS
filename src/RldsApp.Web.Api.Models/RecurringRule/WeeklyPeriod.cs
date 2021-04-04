using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	class WeeklyPeriod : RecurringRule
	{
		[Editable(true)]
		public bool IsMonday { get; set; }

		[Editable(true)]
		public bool IsTuesday { get; set; }

		[Editable(true)]
		public bool IsWednesday { get; set; }

		[Editable(true)]
		public bool IsThursday { get; set; }

		[Editable(true)]
		public bool IsFriday { get; set; }

		[Editable(true)]
		public bool IsSaturday { get; set; }

		[Editable(true)]
		public bool IsSunday { get; set; }
	}
}
