namespace RldsApp.Common
{
	public static class ProjectStatus
	{
		public static readonly int Created = 0;
		public static readonly int Verified = 1;
		public static readonly int Ready = 2;
		public static readonly int InProgress = 3;
		public static readonly int ReadyForReview = 4;
		public static readonly int InReview = 5;
		public static readonly int Completed = 6;
	}
}
