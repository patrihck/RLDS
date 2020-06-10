using System;
using System.Collections.Generic;

namespace RldsApp.Data.Entities
{
	public class Task : IVersionedEntity
	{
		private readonly IList<User> _assignees = new List<User>();

		public virtual long Id { get; set; }
		public virtual string Subject { get; set; }
		public virtual DateTime? StartDate { get; set; }
		public virtual DateTime? DueDate { get; set; }
		public virtual DateTime CreatedDate { get; set; }
		public virtual DateTime? CompletedDate { get; set; }
		public virtual TransactionStatus Status { get; set; }
		public virtual User CreatedBy { get; set; }

		public virtual IList<User> Assignees
		{
			get { return _assignees; }
		}

		public virtual byte[] Version { get; set; }
	}
}
