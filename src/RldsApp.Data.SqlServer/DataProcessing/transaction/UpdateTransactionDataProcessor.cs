using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using RldsApp.Data.DataProcessing.transaction;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.transaction
{
    class UpdateTransactionDataProcessor : IUpdateTransactionDataProcessor
    {
        private readonly ISession _session;

        public UpdateTransactionDataProcessor(ISession session)
        {
            _session = session;
        }

        public Transaction GetUpdatedTransaction(long transactionId, Dictionary<string, object> updatedPropertyValueMap)
        {
            var transaction = GetValidTransaction(transactionId);
            var propertyInfos = typeof(Category).GetProperties();

            foreach (var propertyValuePair in updatedPropertyValueMap)
            {
                propertyInfos.Single(x => x.Name == propertyValuePair.Key)
                    .SetValue(transaction, propertyValuePair.Value);
            }

            _session.SaveOrUpdate(transaction);
            return transaction;
        }

        public virtual Transaction GetValidTransaction(long transactionId)
        {
            var transaction = _session.Get<Transaction>(transactionId);

            if (transaction == null)
            {
                throw new RootObjectNotFoundException("Transaction not found");
            }

            return transaction;
        }
    }
}
