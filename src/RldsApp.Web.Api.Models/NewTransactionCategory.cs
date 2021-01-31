using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class NewTransactionCategory
	{
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }

		public TransactionCategoryLeaf Root { get; set; }
	}
}
