using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewRecurringTransaction
	{
		[Required]
		public User User { get; set; }

		[Required]
		public Account Sender { get; set; }

		[Required]
		public Account Receiver { get; set; }

		[Required]
		public TransactionType Type { get; set; }

		[Required]
		public TransactionCategory Category { get; set; }

		[Required]
		public Currency Currency { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Description { get; set; }

		[Required]
		public decimal Amount { get; set; }
	}
}
