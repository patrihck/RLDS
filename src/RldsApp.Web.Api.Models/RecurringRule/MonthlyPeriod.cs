using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class MonthlyPeriod : RecurringRule
	{
		[Editable(true)]
		public int SelectedDay { get; set; }
	}
}
