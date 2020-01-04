using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
    public class Account : IVersionedEntity
	{
		private readonly IList<User> _users = new List<User>();

		public int AccountId { get; set; }

        public User User { get; set; }

        public Currency Currency { get; set; }

        public Group Group { get; set; }

        public AccountType AccountType { get; set; }

        public decimal StartAmount { get; set; }

		public virtual IList<User> Users => _users;

		public byte[] Version { get ; set; }
    }
}
