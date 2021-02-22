using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class BarChart
	{
		public class DataSet
		{
			[Required]
			[Editable(false)]
			public string Label { get; set; }

			[Required]
			[Editable(false)]
			public List<decimal> Data { get; set; }
		}

		[Required]
		[Editable(false)]
		public List<string> Labels { get; set; }

		[Required]
		[Editable(false)]
		public List<DataSet> DataSets { get; set; }

	}
}
