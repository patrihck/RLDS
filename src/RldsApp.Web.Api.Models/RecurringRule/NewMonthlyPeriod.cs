using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewMonthlyPeriod : NewRecurringRule
	{
		[Required]
		public int SelectedDay { get; set; }
	}
}
