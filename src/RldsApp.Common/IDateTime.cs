using System;

namespace RldsApp.Common
{
	public interface IDateTime
	{
		DateTime UtcNow { get; }
	}
}
