using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class UpdateAccountDataProcessor : IUpdateAccountDataProcessor
	{
		private readonly ISession _session;

		public UpdateAccountDataProcessor(ISession session)
		{
			_session = session;
		}

		public Account UpdateAccount(long accountId, PropertyValueMapType updatedPropertyValueMap)
		{
			var account = _session.GetRootEntity<Account>(accountId, () => Messages.AccountNotFound);
			var propertyInfos = typeof(Account).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos
					.Single(x => x.Name == propertyValuePair.Key)
					.SetValue(account, propertyValuePair.Value);
			}

			AddAccountDataProcessor.GetChildEntities(_session, account);

			_session.SaveOrUpdate(account);
			_session.Flush();

			return account;
		}
	}
}
