using System.ComponentModel;

namespace RldsApp.Common
{
	public static class PrimitiveTypeParser
	{
		public static T Parse<T>(string valueAsString)
		{
			var converter = TypeDescriptor.GetConverter(typeof(T));
			var result = converter.ConvertFromString(valueAsString);
			return (T)result;
		}
	}
}
