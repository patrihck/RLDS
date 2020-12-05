using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.SqlServer.DataProcessing.WeeklyDataProcessor
{
	public class AllWeeklyDataProcessor : IAllWeeklyDataProcessor
	{
		private readonly ISession _session;

		public AllWeeklyDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Weekly> GetWeeklys(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Weekly>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var periods = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Weekly>(periods, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}

