namespace RldsApp.Common.Security
{
	public interface IUserSession
	{
		string Login { get; }
		string Firstname { get; }
		string Lastname { get; }
		bool IsInRole(string roleName);
	}
}
