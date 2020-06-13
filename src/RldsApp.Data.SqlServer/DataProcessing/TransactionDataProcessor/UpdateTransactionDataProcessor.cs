using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
	public class UpdateTransactionDataProcessor : IUpdateTransactionDataProcessor
	{
		private readonly ISession _session;

		public UpdateTransactionDataProcessor(ISession session)
		{
			_session = session;
		}

		public Transaction UpdateTransaction(long transactionId, PropertyValueMapType updatedPropertyValueMap)
		{
			var transaction = _session.GetRootEntity<Transaction>(transactionId, () => Messages.TransactionNotFound);
			var propertyInfos = typeof(Transaction).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
					.SetValue(transaction, propertyValuePair.Value);
			}

			AddTransactionDataProcessor.GetChildEntities(_session, transaction);

			_session.SaveOrUpdate(transaction);
			_session.Flush();

			return transaction;
		}
	}
}
