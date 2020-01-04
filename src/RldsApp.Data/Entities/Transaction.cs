using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
	class Transaction : IVersionedEntity
	{
		public virtual long TransactionId { get; set; }

		public virtual long UserId { get; set; }

		public virtual long SourceAccountId { get; set; }

		public virtual long TargetAccountId { get; set; }

		public virtual long TransactionStateId { get; set; }

		public virtual long CategoryId { get; set; }

		public virtual int Type { get; set; }

		public virtual DateTime Date { get; set; }

		public virtual string Description { get; set; }

		public virtual Decimal Amount { get; set; }

		public virtual byte[] Version { get; set; }
	}
}
