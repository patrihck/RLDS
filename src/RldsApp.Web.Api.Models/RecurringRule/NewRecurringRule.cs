using RldsApp.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewRecurringRule
	{
		[Required]
		public User User { get; set; }

		[Required]
		public Account Sender { get; set; }

		[Required]
		public Account Receiver { get; set; } 

		[Required]
		public TransactionCategory Category { get; set; }

		[Required]
		public Currency Currency { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Description { get; set; }

		[Required]
		public decimal Amount { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public RulePeriod RulePeriod { get; set; }
	}
}
