using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class NewRecurringTransactionRule
	{
		[Required]
		public RecurringTransaction RecurringTransaction { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }
	}
}
