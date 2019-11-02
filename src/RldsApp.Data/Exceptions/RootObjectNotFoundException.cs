using System;

namespace RldsApp.Data.Exceptions
{
	[Serializable]
	public class RootObjectNotFoundException : Exception
	{
		public RootObjectNotFoundException(string message) : base(message)
		{
		}
	}
}
