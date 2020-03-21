using System;
using System.Collections.Generic;

namespace RldsApp.Data.Entities
{
    public class Task : IVersionedEntity
    {
        private readonly IList<User> _users = new List<User>();

        public virtual IList<User> Users => _users;

        public virtual long TaskId { get; set; }

        public virtual string Subject { get; set; }

        public virtual DateTime? StartDate { get; set; }

        public virtual DateTime? DueDate { get; set; }

        public virtual DateTime? CompletedDate { get; set; }

        public virtual TaskStatus Status { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
