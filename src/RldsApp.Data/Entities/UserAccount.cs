using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
    public class UserAccount
    {
        public User User { get; set; }

        public Account Account { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
