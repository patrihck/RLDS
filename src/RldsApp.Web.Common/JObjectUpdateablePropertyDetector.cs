using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace RldsApp.Web.Common
{
	public class JObjectUpdateablePropertyDetector : IUpdateablePropertyDetector
	{
		public IEnumerable<string> GetNamesOfPropertiesToUpdate<TTargetType>(object objectContainingUpdatedData)
		{
			var objectDataAsJObject = (JObject)objectContainingUpdatedData;
			var namesOfSuppliedProperties = new HashSet<string>(objectDataAsJObject.Properties().Select(x => x.Name), StringComparer.InvariantCultureIgnoreCase);

			var result = new List<string>();
			foreach (var prop in typeof(TTargetType).GetProperties())
			{
				if (!namesOfSuppliedProperties.Contains(prop.Name))
					continue;

				var editableAttribute = prop.GetCustomAttribute<EditableAttribute>();
				if (editableAttribute != null && editableAttribute.AllowEdit)
					result.Add(prop.Name);
			}
			return result;
		}

		public Dictionary<string, object> GetPropertyValueMap<TModel, TEntity>(JObject fragment, TModel model, TEntity entity)
		{
			var modelProps = typeof(TModel).GetProperties();
			var entityProps = typeof(TEntity).GetProperties();
			var allProps = new HashSet<string>(fragment.Properties().Select(x => x.Name), StringComparer.InvariantCultureIgnoreCase);
			var result = new Dictionary<string, object>();

			foreach (var modelProp in modelProps)
			{
				if (!allProps.Contains(modelProp.Name))
					continue;

				var editableAttribute = modelProp.GetCustomAttribute<EditableAttribute>();
				if (editableAttribute == null || !editableAttribute.AllowEdit)
					continue;

				var entityProp = entityProps.FirstOrDefault(q => q.Name == modelProp.Name);
				if (entityProp == null)
					continue;

				var value = entityProp.GetValue(entity);
				result.Add(entityProp.Name, value);
			}

			return result;
		}
	}
}
