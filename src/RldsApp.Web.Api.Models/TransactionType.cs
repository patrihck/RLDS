using System.ComponentModel.DataAnnotations;
using RldsApp.Common;

namespace RldsApp.Web.Api.Models
{
	public class TransactionType
	{
		[Key]
		public TransactionTypeValue Id { get; set; }

		[Editable(false)]
		public string Name { get; set; }
	}
}
