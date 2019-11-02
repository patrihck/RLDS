using System;

namespace RldsApp.Common
{
	public class DateTimeAdapter : IDateTime
	{
		public DateTime UtcNow
		{
			get { return DateTime.UtcNow; }
		}
	}
}
