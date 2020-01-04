using System;

namespace RldsApp.Data.Entities
{
	class Transaction : IVersionedEntity
	{
		public virtual long TransactionId { get; set; }

		public virtual User User { get; set; }

		public virtual Account SourceAccount { get; set; }

		public virtual Account TargetAccount { get; set; }

		public virtual TransactionStatus TransactionState { get; set; }

		public virtual Category Category { get; set; }

		public virtual int Type { get; set; }

		public virtual DateTime Date { get; set; }

		public virtual string Description { get; set; }

		public virtual Decimal Amount { get; set; }

		public virtual byte[] Version { get; set; }
	}
}
