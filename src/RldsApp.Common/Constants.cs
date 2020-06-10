namespace RldsApp.Common
{
	public static class Constants
	{
		public static class MediaTypeNames
		{
			public static string ApplicationXml = "application/xml";
			public static string TextXml = "text/xml";
			public static string ApplicationJson = "application/json";
			public static string TextJson = "text/json";
		}

		public static class Paging
		{
			public const int MinPageSize = 1;
			public const int MinPageNumber = 1;
			public const int DefaultPageNumber = 1;
		}

		public static class CommonParameterNames
		{
			public const string PageNumber = "pageNumber";
			public const string PageSize = "pageSize";
		}

		public static class CommonLinkRelValues
		{
			public const string Self = "self";
			public const string All = "all";
			public const string CurrentPage = "currentPage";
			public const string PreviousPage = "previousPage";
			public const string NextPage = "nextPage";
		}

		public static class CommonRoutingDefinitions
		{
			public const string ApiSegmentName = "api";
			public const string ApiVersionSegmentName = "apiVersion";
			public const string CurrentApiVersion = "1.0";
		}

		public static class RoleNames
		{
			public const string AllRoles = "User, SuperUser, Admin";
			public const string Admin = "Admin";
			public const string SuperUser = "SuperUser";
			public const string User = "User";
		}

		public static class Messages
		{
			public const string LoggerInfoOk = "Request has been finished successfuly";
			public const string LoggerInfoError = "Something went wrong. Status code is other than 200";
			public const string UserNotFound = "User not found";
			public const string RoleNotFound = "Role not found";
			public const string CurrencyNotFound = "Currency not found";
			public const string StatusNotFound = "Status not found";
			public const string ProjectNotFound = "Project not found";
			public const string JobNotFound = "Job not found or access denied";
			public const string ToolNotFound = "Tool not found";
			public const string VulnDescriptionNotFound = "Vulnerability description not found";
			public const string VulnClassNotFound = "Vulnerability class not found";
			public const string VulnerabilityNotFound = "Vulnerability not found";
			public const string UnauthorizedMessage = "Unauthorized request";
			public const string TokenCreatedMessage = "JWT Token created successfuly";
			public const string NotReadyMessage = "Incorrect project status. Expected status of 'Ready'. Update your project data to continue.";
			public const string TransactionNotFound = "Transaction not found.";
			public const string TransactionStatusNotFound = "Transaction Status has not been founded.";
			public const string AccountNotFound = "Account not found";
			public const string GroupNotFound = "Group not found";
			public const string TransactionCategoryNotFound = "Transaction category not found";
			public const string TransactionTypeNotFound = "Transaction type not found";
			public const string CurrencyRateNotFound = "Currency rate not found";
		}

		//--------------------

		public static class TransactionType
		{
			public const int Incoming = 0;
			public const int Outgoing = 1;
			public const int Transfer = 2;
			public const int Loan = 3;
		}

		public const string DefaultLegacyNamespace = "http://tempuri.org/";

		public const int January = 1;
		public const int February = 2;
		public const int March = 3;
		public const int April = 4;
		public const int May = 5;
		public const int June = 6;
		public const int July = 7;
		public const int August = 8;
		public const int September = 9;
		public const int October = 10;
		public const int November = 11;
		public const int December = 12;

		public const int MockYear = 2018;

		public const string Firstname = "Firstname";
		public const string Lastname = "Lastname";
		public const string AvatarPath = "avatarpath";
		public const string Expiration = "expiration";
	}
}
