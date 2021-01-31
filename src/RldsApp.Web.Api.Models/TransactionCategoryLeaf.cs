using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class TransactionCategoryLeaf
	{
		private List<Link> _links;

		[Key]
		[Editable(true)]
		public long Id { get; set; }

		[Editable(false)]
		public string Name { get; set; }

		[Editable(false)]
		public long? RootId { get; set; }

		[Editable(false)]
		public List<Link> Links
		{
			get { return _links ?? (_links = new List<Link>()); }
			set { _links = value; }
		}

		public void AddLink(Link link)
		{
			Links.Add(link);
		}
	}
}
