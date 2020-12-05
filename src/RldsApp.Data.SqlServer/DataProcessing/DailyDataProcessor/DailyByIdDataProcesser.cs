using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.DailyDataProcessor
{
    public class DailyByIdDataProcesser : IDailyByIdDataProcessor
	{
		private readonly ISession _session;

		public DailyByIdDataProcesser(ISession session)
		{
			_session = session;
		}

		public Daily GetDailyById(long dailyId)
		{
			var daily = _session.Get<Daily>(dailyId);
			return daily;
		}
	}
}

