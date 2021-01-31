using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringTransactionDataProcessor
{
    public class UpdateRecurringTransactionDataProcessor : IUpdateRecurringTransactionDataProcessor
	{
		private readonly ISession _session;

		public UpdateRecurringTransactionDataProcessor(ISession session)
		{
			_session = session;
		}

		public RecurringTransaction UpdateRecurringTransaction(long recurringTransactionId, PropertyValueMapType updatedPropertyValueMap)
		{
			var recuringTransaction = _session.GetRootEntity<RecurringTransaction>(recurringTransactionId, () => Messages.RecurringTransactionNotFound);
			var propertyInfos = typeof(RecurringTransaction).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos
					.Single(x => x.Name == propertyValuePair.Key)
					.SetValue(recuringTransaction, propertyValuePair.Value);
			}

			AddRecurringTransactionDataProcessor.GetChildEntities(_session, recuringTransaction);

			_session.SaveOrUpdate(recuringTransaction);
			_session.Flush();

			return recuringTransaction;
		}
	}
}
