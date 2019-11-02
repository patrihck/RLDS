using System;

namespace RldsApp.Common
{
	public class BusinessRuleViolationException : Exception
	{
		public BusinessRuleViolationException(string incorrectTaskStatus) :
			base(incorrectTaskStatus)
		{
		}
	}
}
