using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.MonthlyDataProcessor
{
    public class MonthlyByIdDataProcesser : IMonthlyByIdDataProcessor
	{
		private readonly ISession _session;

		public MonthlyByIdDataProcesser(ISession session)
		{
			_session = session;
		}

		public Monthly GetMonthlyById(long monthId)
		{
			var month = _session.Get<Monthly>(monthId);
			return month;
		}
	}
}

