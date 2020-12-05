using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.PeriodDataProcessor
{
    public class PeriodByIdDataProcesser : IPeriodByIdDataProcessor
	{
		private readonly ISession _session;

		public PeriodByIdDataProcesser(ISession session)
		{
			_session = session;
		}

		public Period GetPeriodById(long periodId)
		{
			var period = _session.Get<Period>(periodId);
			return period;
		}
	}
}

