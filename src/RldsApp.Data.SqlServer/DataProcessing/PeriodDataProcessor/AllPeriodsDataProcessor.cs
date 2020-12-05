using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.SqlServer.DataProcessing.PeriodDataProcessor
{
	public class AllPeriodsDataProcessor : IAllPeriodsDataProcessor
	{
		private readonly ISession _session;

		public AllPeriodsDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Period> GetPeriods(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Period>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var periods = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Period>(periods, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}

