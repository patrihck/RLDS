using NHibernate;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringRuleDataProcessor
{
	public class AddRecurringRuleDataProcessor : IAddRecurringRuleDataProcessor
	{
		private readonly ISession _session;

		public AddRecurringRuleDataProcessor(ISession session)
		{
			_session = session;
		}

		public RecurringRule AddRecurringRule(RecurringRule recurringRule)
		{
			GetChildEntities(_session, recurringRule);

			_session.SaveOrUpdate(recurringRule);
			_session.Flush();

			return recurringRule;
		}

		internal static void GetChildEntities(ISession session, RecurringRule recurringRule)
		{
			recurringRule.User = session.GetChildEntity(recurringRule.User, q => q.Id, () => Messages.UserNotFound);
			recurringRule.Sender = session.GetChildEntity(recurringRule.Sender, q => q.Id, () => Messages.AccountNotFound);
			recurringRule.Receiver = session.GetChildEntity(recurringRule.Receiver, q => q.Id, () => Messages.AccountNotFound);
			recurringRule.Type = session.GetChildEntity(recurringRule.Type, q => q.Id, () => Messages.TransactionTypeNotFound);
			recurringRule.Category = session.GetChildEntity(recurringRule.Category, q => q.Id, () => Messages.TransactionCategoryNotFound);
			recurringRule.Currency = session.GetChildEntity(recurringRule.Currency, q => q.Id, () => Messages.CurrencyNotFound);
		}
	}
}
