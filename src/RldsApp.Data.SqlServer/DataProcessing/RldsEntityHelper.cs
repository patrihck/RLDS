using System;
using NHibernate;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	internal static class RldsEntityHelper
	{
		public static TChild GetChildEntity<TChild, TKey>(this ISession session, TChild current, Func<TChild, TKey> keyGetter, Func<string> errMsg)
			where TChild : class
		{
			if (current == null)
				return null;

			var id = keyGetter(current);
			var persisted = session.Get<TChild>(id);
			if (persisted == null)
			{
				var msg = String.Format(errMsg(), id);
				throw new ChildObjectNotFoundException(msg);
			}
			return persisted;
		}

		public static TChild GetRootEntity<TChild>(this ISession session, object id, Func<string> errMsg)
			where TChild : class
		{
			var persisted = session.Get<TChild>(id);
			if (persisted == null)
			{
				var msg = errMsg();
				throw new RootObjectNotFoundException(msg);
			}
			return persisted;
		}
	}
}
