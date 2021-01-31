using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class UpdateTransactionCategoryDataProcessor : IUpdateTransactionCategoryDataProcessor
	{
		private readonly ISession _session;

		public UpdateTransactionCategoryDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionCategory UpdateTransactionCategory(long transactionCategoryId, PropertyValueMapType updatedPropertyValueMap)
		{
			var transactionCategory = _session.GetRootEntity<TransactionCategory>(transactionCategoryId, () => Messages.TransactionCategoryNotFound);
			var propertyInfos = typeof(TransactionCategory).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos
					.Single(x => x.Name == propertyValuePair.Key)
					.SetValue(transactionCategory, propertyValuePair.Value);
			}

			AddTransactionCategoryDataProcessor.GetChildEntities(_session, transactionCategory);

			_session.SaveOrUpdate(transactionCategory);
			_session.Flush();

			return transactionCategory;
		}
	}
}
