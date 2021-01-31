using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Data.Entities
{
	public class RecurringTransactionRule : IVersionedEntity
	{
		[Key]
		public virtual long Id { get; set; }
		public virtual RecurringTransaction RecurringTransaction { get; set; }
		public virtual bool IsActive { get; set; }
		public virtual DateTime? StartDate { get; set; }
		public virtual DateTime? EndDate { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
