using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class HomePageCharts
	{
		[Required]
		[Editable(false)]
		public BarChart Bar { get; set; }

		[Required]
		[Editable(false)]
		public DoughnutChart Doughnut { get; set; }
	}
}
