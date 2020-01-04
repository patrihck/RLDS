using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
    public class AccountType : IVersionedEntity
	{
		public virtual long AccountTypeId { get; set; }

		public virtual User User { get; set; }

		public virtual string Name { get; set; }

		public virtual string Description { get; set; }

		public virtual byte[] Version { get; set; }
	}
}
