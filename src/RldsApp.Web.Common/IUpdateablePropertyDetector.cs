using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace RldsApp.Web.Common
{
	public interface IUpdateablePropertyDetector
	{
		IEnumerable<string> GetNamesOfPropertiesToUpdate<TTargetType>(object objectContainingUpdatedData);

		Dictionary<string, object> GetPropertyValueMap<TModel, TEntity>(JObject fragmentAsJObject, TModel model, TEntity entity);
	}
}
