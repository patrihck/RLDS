using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	class NewWeeklyPeriod : NewRecurringRule
	{
		[Required]
		public bool IsMonday { get; set; }

		[Required]
		public bool IsTuesday { get; set; }

		[Required]
		public bool IsWednesday { get; set; }

		[Required]
		public bool IsThursday { get; set; }

		[Required]
		public bool IsFriday { get; set; }

		[Required]
		public bool IsSaturday { get; set; }

		[Required]
		public bool IsSunday { get; set; }
	}
}
