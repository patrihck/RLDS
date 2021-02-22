using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class DoughnutChart
	{
		[Required]
		[Editable(false)]
		public List<string> Labels { get; set;  }

		[Required]
		[Editable(false)]
		public List<decimal> DataSet { get; set;  }
	}
}
