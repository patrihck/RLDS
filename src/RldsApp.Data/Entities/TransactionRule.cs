using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Data.Entities
{
	public class TransactionRule
	{
		[Key]
		public virtual long Id { get; set; }

		public virtual DateTime DateFrom { get; set; }

		public virtual DateTime DateTo { get; set; }

		public virtual User User { get; set; }

		public virtual Account Sender { get; set; }

		public virtual Account Receiver { get; set; }

		public virtual TransactionCategory Category { get; set; }

		public virtual Currency Currency { get; set; }

		public virtual string Description { get; set; }

		public virtual decimal Amount { get; set; }

		public virtual Recurrence Period { get; set; }

		public virtual byte[] Version { get; set; }
	}
}
