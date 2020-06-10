using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Data.Entities
{
	public class Transaction : IVersionedEntity
	{
		[Key]
		public virtual long Id { get; set; }

		public virtual DateTime Date { get; set; }

		public virtual User User { get; set; }

		public virtual Account Sender { get; set; }

		public virtual Account Receiver { get; set; }

		public virtual TransactionType Type { get; set; }

		public virtual TransactionCategory Category { get; set; }

		public virtual TransactionStatus Status { get; set; }

		public virtual Currency Currency { get; set; }

		public virtual string Description { get; set; }

		public virtual decimal Amount { get; set; }

		public virtual byte[] Version { get; set; }
	}
}
