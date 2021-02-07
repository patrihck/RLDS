using System;
using System.Diagnostics;

namespace RldsApp.Common
{
    public static class Check
	{
		[DebuggerStepThrough]
		public static void IsNotEmpty(string argument, string argumentName)
		{
			const string format = "Argument \"{0}\" cannot be empty.";

			if (argument == null)
				throw new ArgumentNullException(argumentName);
			if (argument.Length == 0)
				throw new ArgumentException(String.Format(format, argumentName), argumentName);
		}

		[DebuggerStepThrough]
		public static void IsNotEmpty(string argument, string argumentName, string exceptionMessage)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName);
			if (argument.Length == 0)
				throw new ArgumentException(exceptionMessage, argumentName);
		}

		[DebuggerStepThrough]
		public static void IsNotEmpty(byte[] argument, string argumentName)
		{
			const string format = "Byte array \"{0}\" cannot be empty.";

			if (argument == null)
				throw new ArgumentNullException(argumentName);
			if (argument.Length == 0)
				throw new ArgumentException(String.Format(format, argumentName), argumentName);
		}

		[DebuggerStepThrough]
		public static void IsNotEmpty(byte[] argument, string argumentName, string exceptionMessage)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName);
			if (argument.Length == 0)
				throw new ArgumentException(exceptionMessage, argumentName);
		}

		[DebuggerStepThrough]
		public static void IsNotEmpty(Guid argument, string argumentName)
		{
			const string format = "Argument \"{0}\" cannot be an empty GUID.";

			if (argument == Guid.Empty)
				throw new ArgumentException(String.Format(format, argumentName), argumentName);
		}

		[DebuggerStepThrough]
		public static void IsNotEmpty(Guid argument, string argumentName, string exceptionMessage)
		{
			if (argument == Guid.Empty)
				throw new ArgumentException(exceptionMessage, argumentName);
		}

		[DebuggerStepThrough]
		public static void IsNotNull<TParam>(TParam argument, string argumentName)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName);
		}

		[DebuggerStepThrough]
		public static void IsNotNull<TParam>(TParam argument, string argumentName, string exceptionMessage)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName, exceptionMessage);
		}
	}
}
