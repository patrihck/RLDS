using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
<<<<<<< HEAD
    class Class1
    {
    }
=======
    public class AccountType : IVersionedEntity
	{
		private readonly IList<User> _users = new List<User>();

		public virtual long AccountTypeId { get; set; }

		public virtual string Name { get; set; }

		public virtual string Description { get; set; }

		public virtual IList<User> User => _users;

		public virtual byte[] Version { get; set; }
	}
>>>>>>> development
}
