using System.Collections.Generic;

namespace RldsApp.Web.Common
{
	public interface IUpdateablePropertyDetector
	{
		IEnumerable<string> GetNamesOfPropertiesToUpdate<TTargetType>(object objectContainingUpdatedData);
	}
}
