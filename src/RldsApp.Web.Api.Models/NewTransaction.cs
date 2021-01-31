using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewTransaction
	{
		[Required]
		public DateTime Date { get; set; }

		[Required]
		public UserLeaf User { get; set; }

		[Required]
		public Account Sender { get; set; }

		[Required]
		public Account Receiver { get; set; }

		[Required]
		public TransactionType Type { get; set; }

		[Required]
		public TransactionCategory Category { get; set; }

		[Required]
		public TransactionStatus Status { get; set; }

		[Required]
		public Currency Currency { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Description { get; set; }

		[Required]
		public decimal Amount { get; set; }

		public RecurringTransaction RecurringTransaction { get; set; }
	}
}
