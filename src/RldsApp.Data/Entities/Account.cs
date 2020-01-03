using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
    public class Account : IVersionedEntity
    {
        public int AccountId { get; set; }

        public Currency Currency { get; set; }

        public User User { get; set; }

        public Group Group { get; set; }

        public AccountType AccountType { get; set; }

        public decimal StartAmount { get; set; }

        public byte[] Version { get ; set; }
    }
}
