using RldsApp.Common;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class TransactionStatus
	{
		[Editable(false)]
		public TransactionStatusValue Id { get; set; }

		[Editable(false)]
		public string Name { get; set; }

		[Editable(false)]
		public int Ordinal { get; set; }
	}
}
