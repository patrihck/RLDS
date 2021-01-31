using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewRecurringTransactionMonthRule : NewRecurringTransactionRule
	{
		[Required]
		public int SelectedDay { get; set; }
	}
}
