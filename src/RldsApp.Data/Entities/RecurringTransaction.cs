using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Data.Entities
{
    public class RecurringTransaction : IVersionedEntity
	{
		private readonly IList<RecurringTransactionDayRule> _recurringTransactionDayRules
			= new List<RecurringTransactionDayRule>();
		private readonly IList<RecurringTransactionWeekRule> _recurringTransactionWeekRules
			= new List<RecurringTransactionWeekRule>();
		private readonly IList<RecurringTransactionMonthRule> _recurringTransactionMonthRules
			= new List<RecurringTransactionMonthRule>();

		[Key]
		public virtual long Id { get; set; }
		public virtual User User { get; set; }
		public virtual Account Sender { get; set; }
		public virtual Account Receiver { get; set; }
		public virtual TransactionType Type { get; set; }
		public virtual TransactionCategory Category { get; set; }
		public virtual Currency Currency { get; set; }
		public virtual string Description { get; set; }
		public virtual decimal Amount { get; set; }
		public virtual IList<RecurringTransactionDayRule> RecurringTransactionDayRules
			=> _recurringTransactionDayRules;
		public virtual IList<RecurringTransactionWeekRule> RecurringTransactionWeekRules
			=> _recurringTransactionWeekRules;
		public virtual IList<RecurringTransactionMonthRule> RecurringTransactionMonthRules
			=> _recurringTransactionMonthRules; 
		public virtual byte[] Version { get; set; }
	}
}
