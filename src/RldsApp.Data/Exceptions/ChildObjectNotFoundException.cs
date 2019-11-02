using System;

namespace RldsApp.Data.Exceptions
{
	[Serializable]
	public class ChildObjectNotFoundException : Exception
	{
		public ChildObjectNotFoundException(string message) : base(message)
		{
		}
	}
}
