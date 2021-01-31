using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class RecurringTransactionMonthRule : RecurringTransactionRule
	{
		[Editable(true)]
		public int SelectedDay { get; set; }
	}
}
